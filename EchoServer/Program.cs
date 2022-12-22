using NetMQ;
using NetMQ.Sockets;

namespace EchoServer
{
    public class Program
    {
        public static readonly uint port = 62098;

        public static void Main(string[] args)
        {
            using (var server = new ResponseSocket())
            {
                server.Bind($"tcp://localhost:{port}");

                while (true)
                {
                    var message = server.ReceiveFrameString();
                    Console.WriteLine(message);
                    Thread.Sleep(100);
                    server.SendFrame(message);
                }
            }
        }
    }
}
