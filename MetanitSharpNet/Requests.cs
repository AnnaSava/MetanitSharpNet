using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
                    case 'p':
                        postRequest();
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
            Console.WriteLine("P - отправка данных");
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

        static async void postRequest()
        {
            await PostRequestAsync();
            Thread.Sleep(2000);
            await PostRequestAsync2();
            Thread.Sleep(2000);
            await GetRequest();
        }

        private static async Task PostRequestAsync()
        {
            WebRequest request = WebRequest.Create("http://localhost:1755/Home/PostData");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "sName=Hello world!";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            Console.WriteLine("Запрос выполнен...");
        }

        private static async Task PostRequestAsync2()
        {
            WebRequest request = WebRequest.Create("http://localhost:1755/Home/PostData2");
            request.Method = "POST"; // для отправки используется метод Post
                                     // данные для отправки
            string data = "sName=Иван Иванов&age=31";
            // преобразуем данные в массив байтов
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            // устанавливаем тип содержимого - параметр ContentType
            request.ContentType = "application/x-www-form-urlencoded";
            // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
            request.ContentLength = byteArray.Length;

            //записываем данные в поток запроса
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            Console.WriteLine("Запрос 2 выполнен...");
        }

        private static async Task GetRequest()
        {
            WebRequest request = WebRequest.Create("http://localhost:1755/Home/GetData?sName=Иван Иванов&age=31");
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
            Console.WriteLine("Запрос GET выполнен...");
        }
    }
}
