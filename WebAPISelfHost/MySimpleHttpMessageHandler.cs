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
               message.Content = new StringContent("Hello Self Hosting");
               Console.WriteLine("Htt response sent");
               return message;
           });
            task.Start();
            return task;
        }
    }
}