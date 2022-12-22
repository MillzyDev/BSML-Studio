using NetMQ;
using NetMQ.Sockets;

namespace EchoServer
{
    public class Program
    {
        public static readonly uint port = 62098;

        public static void Main(string[] args)
        {
            using (var client = new RequestSocket())
            {
                client.Connect($"tcp://localhost:{port}");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Sending Hello");
                    client.SendFrame("Hello");
                    var message = client.ReceiveFrameString();
                    Console.WriteLine("Received {0}", message);
                }
            }
        }
    }
}