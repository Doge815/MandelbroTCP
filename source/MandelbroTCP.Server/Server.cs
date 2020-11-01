using MandelbroTCP.Base;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using MandelbroTCP.Server.Calc;


namespace MandelbroTCP.Server
{
    class BrotServer
    {
        HttpListener _listener;

        public BrotServer(string address)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(address);
        }

        public void Start()
        {
            _listener.Start();
            while (true)
            {
                HttpListenerContext request = _listener.GetContext();
                ThreadPool.QueueUserWorkItem(ProcessRequest, request);
            }
        }

        void ProcessRequest(object listenerContext)
        {
            HttpListenerContext context = (HttpListenerContext)listenerContext;
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string requestString;
            using (Stream receiveStream = request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    requestString = readStream.ReadToEnd();
                }
            }

            BrotInfo vals = new BrotInfo(requestString);
            PixelCollection brot = MandelbroTCP.Server.Calc.Brot.GetBrot(vals);
            string serializedBrot = brot.Serialize();

            response.StatusCode = (int)HttpStatusCode.OK;
            byte[] msg = Encoding.UTF8.GetBytes(serializedBrot);
            response.ContentLength64 = msg.Length;
            response.OutputStream.Write(msg, 0, msg.Length);
            response.OutputStream.Close();
        }
    }
}