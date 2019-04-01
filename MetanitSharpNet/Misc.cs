using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
    public static class Misc
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
                    case 's':
                        streams();
                        break;
                    case 'b':
                        binary();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("S - потоки текстовых данных");
            Console.WriteLine("B - потоки бинарных данных");
        }

        static void streams()
        {
            Process.Start("TxtServer.exe");
            Thread.Sleep(1000);
            Process.Start("TxtClient.exe");
        }

        static void binary()
        {
            Process.Start("FinanceServer.exe");
            Thread.Sleep(1000);
            Process.Start("FinanceClient.exe");
        }
    }
}
