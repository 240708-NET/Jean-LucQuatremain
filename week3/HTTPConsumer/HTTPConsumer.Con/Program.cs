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

            string uriPosts = "https://jsonplaceholder.typicode.com/posts/";
            string uriUsers = "https://jsonplaceholder.typicode.com/users";

            HttpClient client = new HttpClient();

            string responsePosts = await client.GetStringAsync(uriPosts);
            string responseUsers = await client.GetStringAsync(uriUsers);

            // Console.WriteLine(response);

            List<Post> postList = JsonSerializer.Deserialize<List<Post>>(responsePosts);
            List<User> userList = JsonSerializer.Deserialize<List<User>>(responseUsers);
        
            foreach (var i in postList)
                foreach (var j in userList)
                    if(i.userId == j.id)
                    {
                        Console.WriteLine(i.title + " by: " + j.name);
                        break;
                    }
        }
    }
}