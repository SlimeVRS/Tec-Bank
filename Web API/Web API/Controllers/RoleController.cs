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
    public class RoleController : ApiController
    {
        public HttpResponseMessage Get()
        {
            Console.WriteLine("This is a get response");
            var response = JsonConvert.DeserializeObject(File.ReadAllText("F:\\Progras\\Web API\\Web API\\DataBase\\Roles.json"));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public string Post(Role role)
        {
            try
            {
                var filePath = @"F:\Progras\Web API\Web API\DataBase\Roles.json";
                var jsonData = File.ReadAllText(filePath);
                var roleList = JsonConvert.DeserializeObject<List<Role>>(jsonData) ?? new List<Role>();
                roleList.Add(new Role()
                {
                    roleName = role.roleName,
                    roleDescription = role.roleDescription
                });

                jsonData = JsonConvert.SerializeObject(roleList);
                File.WriteAllText(filePath, jsonData);
                return "Added Succesfully!!!";
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }
    }
}
