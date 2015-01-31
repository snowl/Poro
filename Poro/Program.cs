using PoroLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Poro
{
    class Program
    {
        static void Main(string[] args)
        {
            PoroServerSettings settings = new PoroServerSettings 
            {
                RTMPSHost = LocalIPAddress()
            };

            PoroServer server = new PoroServer(settings);
            server.Start();

            while (true);
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

            return "";
        }
    }
}
