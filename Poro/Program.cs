using PoroLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poro
{
    class Program
    {
        static void Main(string[] args)
        {
            PoroServerSettings settings = new PoroServerSettings {};

            PoroServer server = new PoroServer(settings);
            server.Start();

            while (true);
        }
    }
}
