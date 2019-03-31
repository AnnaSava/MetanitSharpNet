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
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("U - UDP-чат");
        }

        static void udp()
        {
            Process.Start("UdpClientApp.exe");
            Thread.Sleep(1000);
            Process.Start("UdpClientApp.exe");
        }
    }
}
