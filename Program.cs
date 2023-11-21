using System.Net;
using System.Net.Sockets;
using System.Text;

namespace task_1
{
    internal class Program
    {
        public static void Server()
        {
            UdpClient udpServer = new UdpClient(12345);
            IPEndPoint localRemouteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Ожидаем сообщение от пользователя:");

            while (true)
            {
                try
                {
                    byte[] buffer = udpServer.Receive(ref localRemouteEndPoint);
                    string data = Encoding.ASCII.GetString(buffer);
                    var message = Message.MessageFromJson(data);

                    Console.WriteLine($"Получено сообщение от {message.NickName}," +
                    $" время получения {message.DateMessage}, ");
                    Console.WriteLine(message.TextMessage);

                    string answer = "Сообщение получено!";

                    var answerMessage = new Message()
                    {
                        DateMessage = DateTime.Now,
                        NickName = message.NickName,
                        TextMessage = answer
                    };

                    var answerData = answerMessage.MessageToJson();
                    byte[] bytes = Encoding.ASCII.GetBytes(answerData);
                    udpServer.Send(bytes, bytes.Length, localRemouteEndPoint);

                    Console.WriteLine("Сообщение отпавлено (клиенту)!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void Client(string name, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint localRemouteEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            string message = "Привет!";
            var mess = new Message()
            {
                DateMessage = DateTime.Now,
                NickName = name,
                TextMessage = message
            };

            try
            {
                var data = mess.MessageToJson();
                byte[] bytes = Encoding.ASCII.GetBytes(data);
                udpClient.Send(bytes, bytes.Length, localRemouteEndPoint);

                Console.WriteLine("Сообщение отпавлено!");

                byte[] buffer = udpClient.Receive(ref localRemouteEndPoint);
                data = Encoding.ASCII.GetString(buffer);
                var messageReception = Message.MessageFromJson(data);
                Console.WriteLine($"Получено сообщение от {messageReception.NickName}," +
                $" время получения {messageReception.DateMessage}, ");
                Console.WriteLine(messageReception.TextMessage);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Main(string[] args)
        {
          
            if (args.Length == 0)
            {
                Server();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    new Thread(() => Client(args[0] + i, args[1])).Start();
                }
                
            }
        }
    }
}