using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class AccountController : ApiController
    {
        public HttpResponseMessage Get()
        {
            Console.WriteLine("This is a get response");
            var response = JsonConvert.DeserializeObject(File.ReadAllText("F:\\Progras\\Web API\\Web API\\DataBase\\Accounts.json"));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public string Post(Clients role)
        {
            try
            {
                var data = JsonConvert.DeserializeObject(File.ReadAllText("F:\\Progras\\Web API\\Web API\\DataBase\\Accounts.json"));
                Console.WriteLine(role);
                return "Added succesfully!!!";
            }
            catch (Exception)
            {
                return "Something went wrong...";
            }
        }
    }
}
