using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var app = WebApp.Start<Startup>(new StartOptions("http://localhost:8080")))
            {
                Console.WriteLine("Press any key to stop listener...");
                Console.ReadKey();
            }
        }
    }
}
