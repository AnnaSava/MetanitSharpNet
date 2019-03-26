using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
   public static class TcpProtocol
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
                    case 'h':
                        threadTcp();
                        break;
                    case 'c':
                        tcpChat();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("T - TCP сервер и клиент");
            Console.WriteLine("H - Многопоточное клиент-серверное приложение TCP");
            Console.WriteLine("С - TCP-чат");
        }

        static void tcp()
        {
            Process.Start("TcpListenerApp.exe");
            Thread.Sleep(1000);
            Process.Start("TcpClientApp.exe");
        }

        static void threadTcp()
        {
            Process.Start("ConsoleTcpServer.exe");
            Thread.Sleep(1000);
            Process.Start("ConsoleTcpClient.exe");
            Thread.Sleep(1000);
            Process.Start("ConsoleTcpClient.exe");
        }

        static void tcpChat()
        {
            Process.Start("ChatServer.exe");
            Thread.Sleep(1000);
            Process.Start("ChatClient.exe");
            Thread.Sleep(1000);
            Process.Start("ChatClient.exe");
        }
    }
}
