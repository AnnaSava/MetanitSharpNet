using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetanitSharpNet
{
    public static class Requests
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
                    case 'w':
                        usingWebClient();
                        break;
                    case 'a':
                        usingWebClientAsync();
                        break;
                    case 'x': return;
                }
                Console.ReadKey();
            }
        }

        static void printMenu()
        {
            Console.WriteLine("Нажмите клавишу для вывода информации");
            Console.WriteLine("W - загрузка файла через WebClient");
            Console.WriteLine("A - асинхронная загрузка файла");
        }

        static void usingWebClient()
        {
            WebClient client = new WebClient();

            using (Stream stream = client.OpenRead("http://uploads.athn.ru/sometext.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            Console.WriteLine("Файл загружен");
        }

        static void usingWebClientAsync()
        {
            DownloadFileAsync().GetAwaiter();

            Console.WriteLine("Файл загружен");
        }

        private static async Task DownloadFileAsync()
        {
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(new Uri("http://uploads.athn.ru/sometext.txt"), "mytxtFile.txt");
        }
    }
}
