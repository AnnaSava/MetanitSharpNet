using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
    class Program
    {
        static void Main(string[] args)
        {
            char key;

            while (true)
            {
                printMenu();

                key = Console.ReadKey().KeyChar;

                Console.WriteLine();
                switch (key)
                {
                    case 'r':
                        Requests.Run();
                        break;
                    case 's':
                        Sockets.Run();
                        break;
                    case 't':
                        TcpProtocol.Run();
                        break;
                    case 'u':
                        UdpProtocol.Run();
                        break;
                    case 'm':
                        Misc.Run();
                        break;
                    case 'h':
                        HttpProtocol.Run();
                        break;
                    case 'f':
                        FtpProtocol.Run();
                        break;
                }
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для выбора раздела");
            Console.WriteLine("R - отправка запросов");
            Console.WriteLine("S - сокеты");
            Console.WriteLine("T - TCP");
            Console.WriteLine("U - UDP");
            Console.WriteLine("М - разное");
            Console.WriteLine("H - HTTP");
            Console.WriteLine("F - FTP");
        }
    }
}
