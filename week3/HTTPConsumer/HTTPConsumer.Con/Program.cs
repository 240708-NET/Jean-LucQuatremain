using System;
using System.Net.Http;
using HTTPConsumer.Models;
using System.Text.Json;

namespace HTTPConsumer.Con
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello again!");

            string uri = "https://jsonplaceholder.typicode.com/posts/";

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(uri);

            // Console.WriteLine(response);

            List<Post> postList = JsonSerializer.Deserialize<List<Post>>(response);
        
            foreach (var i in postList)
                Console.WriteLine(i.id + ": " + i.title);
        }
    }
}