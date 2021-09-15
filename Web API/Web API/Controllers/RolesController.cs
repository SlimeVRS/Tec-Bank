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
    public class RolesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var filePath = @"DataBase\Roles.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/Roles/{nombre}")]
        [HttpGet]
        public HttpResponseMessage Get(string nombre)
        {
            try
            {
                var filePath = @"DataBase\Roles.json";
                var jsonData = File.ReadAllText(filePath);
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();
                Roles item = roleList.Find(o => o.nombre == nombre);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public string Post(Roles role)
        {
            try
            {
                var filePath = @"DataBase\Roles.json";
                var jsonData = File.ReadAllText(filePath);
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();
                roleList.Add(new Roles()
                {
                    nombre = role.nombre,
                    descripcion = role.descripcion
                });

                jsonData = JsonConvert.SerializeObject(roleList);
                File.WriteAllText(filePath, jsonData);
                return "Added Succesfully!!!";
            }
            catch
            {
                return "Something went wrong";
            }
        }

        [Route("api/Roles/{nombre}")]
        [HttpPut]
        public string Put(Roles role)
        {
            try
            {
                var filePath = @"DataBase\Roles.json";
                var jsonData = File.ReadAllText(filePath);
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();
                foreach (Roles item in roleList)
                {
                    if(item.nombre == role.nombre)
                    {
                        item.descripcion = item.descripcion;
                    }
                }
                jsonData = JsonConvert.SerializeObject(roleList);
                File.WriteAllText(filePath, jsonData);
                return "Update Sucess!!!";
            }
            catch
            {
                return "Something went wrong";
            }
        }
    }
}
