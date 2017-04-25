using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace WebAPISelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new MyConfig("http://localhost:8999");
            var server = new HttpSelfHostServer(config, new MySimpleHttpMessageHandler());
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = System.Web.Http.RouteParameter.Optional });
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Server is up and runnig...");
            Console.WriteLine("Hit enter to call server with client");
            Console.ReadLine();
            var client = new HttpClient(server);
            client.GetAsync("http://localhost:8999/api/my").ContinueWith((t)=> 
            {
                var result = t.Result;
                result.Content.ReadAsStringAsync().ContinueWith((readTask) =>
                {
                    Console.WriteLine("Client got response " + readTask.Result);
                });
            });
        }
    }
}
