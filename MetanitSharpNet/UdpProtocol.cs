using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
   public static class UdpProtocol
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
                    case 'u':
                        udp();
                        break;
                    case 'm':
                        multicast();
                        break;
                    case 'c':
                        chat();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("U - UDP-чат");
            Console.WriteLine("M - широковещательная рассылка");
            Console.WriteLine("C - оконный чат");
        }

        static void udp()
        {
            Process.Start("UdpClientApp.exe");
            Thread.Sleep(1000);
            Process.Start("UdpClientApp.exe");
        }

        static void multicast()
        {
            Process.Start("MulticastApp.exe");
        }

        static void chat()
        {
            Process.Start("UdpChat.exe");
        }
    }
}
