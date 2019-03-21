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
                    case 'q':
                        usingWebRequest();
                        break;
                    case 'r':
                        usingHttpWebRequest();
                        break;
                    case 'c':
                        requestCredentials();
                        break;
                    case 'h':
                        responseHeaders();
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
            Console.WriteLine("Q - WebRequest");
            Console.WriteLine("R - HttpWebRequest");
            Console.WriteLine("C - credentials");
            Console.WriteLine("H - headers");
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

        static void usingWebRequest()
        {
            WebRequest request = WebRequest.Create("http://uploads.athn.ru/sometext.txt");
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
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
            response.Close();
            Console.WriteLine("Запрос выполнен");
        }

        static async void usingHttpWebRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://uploads.athn.ru/sometext.txt");
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }

        static async void requestCredentials()
        {
            Console.WriteLine("Try this example with valid Url!");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://somesite.com/auth");
                request.Credentials = new NetworkCredential("myLogin", "myPassword");
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async void responseHeaders()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://uploads.athn.ru/sometext.txt");
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            WebHeaderCollection headers = response.Headers;
            for (int i = 0; i < headers.Count; i++)
            {
                Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
            }
            response.Close();
        }
    }
}
