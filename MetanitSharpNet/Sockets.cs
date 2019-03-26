using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
   public static class Sockets
    {
        public static void Run()
        {
            char key;

            while (true)
            {
                printMenu();

                key = Console.ReadKey().KeyChar;

                Console.WriteLine();
                switch (key)
                {
                    case 't':
                        tcp();
                        break;
                    case 'u':
                        udp();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("T - TCP");
            Console.WriteLine("U - UDP");
        }

        static void tcp()
        {
            Process.Start("SocketTcpServer.exe");
            Thread.Sleep(1000);
            Process.Start("SocketTcpClient.exe");
        }

        static void udp()
        {
            Process.Start("SocketUdpClient.exe");
            Thread.Sleep(1000);
            Process.Start("SocketUdpClient.exe");
        }
    }
}
