using System;
using System.Net;
using System.Text;
using System.Threading;

namespace PoroLib
{
    class AuthServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, object> _responderMethod;

        public AuthServer(Func<HttpListenerRequest, object> method, params string[] prefixes)
        {
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            if (method == null)
                throw new ArgumentException("method");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            _responderMethod = method;
        }

        public void Start()
        {
            _listener.Start();

            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (_listener.IsListening)
                {
                    HttpListenerContext context = _listener.GetContext();
                    context.Response.Headers[HttpResponseHeader.ContentType] = SetContentType(context.Request.RawUrl);

                    object response = _responderMethod(context.Request);
                    byte[] buf;

                    if (response is string)
                        buf = Encoding.UTF8.GetBytes((string)response);
                    else
                        buf = (byte[])response;

                    context.Response.ContentLength64 = buf.Length;
                    using (var Stream = context.Response.OutputStream)
                    {
                        Stream.Write(buf, 0, buf.Length);
                    }
                }
            });
        }

        public static string SetContentType(string RawUrl)
        {
            if (RawUrl.EndsWith(".png"))
                return "image/png";
            else if (RawUrl.EndsWith(".jpg"))
                return "image/jpeg";
            else if (RawUrl.EndsWith(".css"))
                return "text/css";
            else if (RawUrl.EndsWith(".js"))
                return "text/javascript";

            return "text/html";
        }
    }
}
