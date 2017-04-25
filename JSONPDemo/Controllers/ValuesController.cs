using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JSONPDemo.Controllers
{
    [Authorize]
    public class JSONPController : ApiController
    {

       /// <summary>
       /// Callback = a method that a caller of the service whants the generator of JS to call
       /// </summary>
       /// <param name="id"></param>
       /// <param name="callback"></param>
       /// <returns></returns>
        public HttpResponseMessage Get(int id, string callback)
        {
            var content = new JSONPReturn
            {
                Callback = callback,
                JSON = "{'id':'" + id.ToString() + "', 'data':'Hello from JSONP WEB API Style'"
            };
            var message = Request.CreateResponse(HttpStatusCode.OK, content,
                "application/javascript");
            return message;
        }

       
    }
}
