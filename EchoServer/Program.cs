using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    public class Program
    {
        public static readonly int port = 11000;

        public static void Main(string[] args)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            Console.WriteLine("Listening on {0}:{1}", ipAddress.ToString(), port);

            try
            {
                Socket listener = new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();

                string data = null;
                byte[] bytes = null;
                
                while (true)
                {
                    bytes = new byte[1024];
                    int bytsRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytsRec);

                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                Console.WriteLine("Text recieved : {0}", data);

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
