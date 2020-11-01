using System;

namespace MandelbroTCP.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            BrotServer server = new BrotServer("http://localhost:8000/");
            server.Start();
        }
    }
}
