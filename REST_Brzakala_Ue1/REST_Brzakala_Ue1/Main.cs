using System;
using System.Net;

namespace REST_BRZAKALA_UE1
{
    public class Http
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer();
            server.StartServer();

        }
    }
}
