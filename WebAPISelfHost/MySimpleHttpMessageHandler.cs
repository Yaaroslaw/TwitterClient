using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPISelfHost
{
    public class MySimpleHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Received an http message");
            var task = new Task<HttpResponseMessage>(() =>
           {
               var message = new HttpResponseMessage();
               var userName = Thread.CurrentPrincipal.Identity.Name;
               message.Content = new StringContent("Hello user - " + userName);
               Console.WriteLine("Htt response sent");
               return message;
           });
            task.Start();
            return task;
        }
    }
}