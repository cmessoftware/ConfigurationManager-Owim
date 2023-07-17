using CacheManager.Core;
using ConfigurationManager.App_Start;
using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Threading;

namespace ConfigurationManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestWebApi();
            //TestCacheManger();

            string baseAddress = "http://localhost:3000/";
            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);
            
        }
    

        private static void TestCacheManger()
        {
            var cache = CacheFactory.Build("getStartedCache", settings =>
            {
                settings.WithSystemRuntimeCacheHandle("handleName").
                         WithExpiration(ExpirationMode.Sliding, TimeSpan.FromSeconds(10));
               
            });

            cache.Add("keyA", "valueA");
            cache.Put("keyB", 23);
            cache.Update("keyB", v => 42);

            Console.WriteLine("KeyA is " + cache.Get("keyA"));      // should be valueA
            Console.WriteLine("KeyB is " + cache.Get("keyB"));      // should be 42

            Thread.Sleep(15000); //Espero a que expire el cache.

            Console.WriteLine("KeyA after expire time is " + cache.Get("keyA"));     
            Console.WriteLine("KeyB after expire time is " + cache.Get("keyB"));     


            cache.Remove("keyA");

            Console.WriteLine("KeyA removed? " + (cache.Get("keyA") == null).ToString());

            Console.WriteLine("We are done...");
            Console.ReadKey();
        }

        private static void TestWebApi()
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpClient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
