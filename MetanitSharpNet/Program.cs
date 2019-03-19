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
                }
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для выбора раздела");
            Console.WriteLine("R - отправка запросов");
        }
    }
}
