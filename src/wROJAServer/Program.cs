using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using wROJAServer.services;

namespace wROJAServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = Server.getInstance();

            server.StartUp();
            Console.ReadLine();
            server.CleanUp();
        }
    }
}
