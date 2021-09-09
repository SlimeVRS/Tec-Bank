using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class UsersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var filePath = @"F:\Progras\Web API\Web API\DataBase\Users.json"; ;
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public HttpResponseMessage Get(string userName, string userPassword)
        {
            try
            {
                var filePath = @"F:\Progras\Web API\Web API\DataBase\Users.json";
                var jsonData = File.ReadAllText(filePath);
                var userList = JsonConvert.DeserializeObject<List<Users>>(jsonData) ?? new List<Users>();

                return Request.CreateResponse(HttpStatusCode.OK);
                
                /**
                if(userList.Find(o => o.userName.ToString() == userName && o.userPassword.ToString() == userPassword))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }*/
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound); ;
            }
            
        }
    }
}
