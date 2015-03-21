using PoroLib;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Poro
{
    class Program
    {
        static ConsoleEventDelegate handler;
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        private static PoroServerSettings _settings;

        static void Main(string[] args)
        {
            Console.Title = "Poro";

            _settings = new PoroServerSettings 
            {
                RTMPSHost = LocalIPAddress()
            };

            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            PoroServer server = new PoroServer(_settings);
            server.Start();

            while (true);
        }

        //Remove certificate on close
        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                var certificateStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                certificateStore.Open(OpenFlags.MaxAllowed);
                foreach (var cert in certificateStore.Certificates)
                {
                    if (cert.IssuerName.Name == string.Format("CN={0}", _settings.RTMPSHost))
                    {
                        certificateStore.Remove(cert);
                    }
                }
                certificateStore.Close();
            }
            return false;
        }

        public static string LocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No connection has been found");
        }
    }
}
