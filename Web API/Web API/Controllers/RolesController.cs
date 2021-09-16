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

    /**
     * En esta clase se encuentran todos los metodos que se pueden hacer desde el controlador de roles
     * Esto incluye:
     * - Get genera
     * - Get individual
     * - Post
     * - Put
     */
    public class RolesController : ApiController
    {
        /**
         *El metodo get devuelte todos los roles
         <returns>Respuesta del api en formato json de todo el contenido
         */
        public HttpResponseMessage Get()
        {
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /**
         * El metodo get individual devuelve un solo item segun el nombre del rol
         * <returns>Respuesta del api en formato json de un solo item
         */
        [Route("api/Roles/{nombre}")]
        [HttpGet]
        public HttpResponseMessage Get(string nombre)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Roles.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();

                /// Se busca un rol en especifico
                Roles item = roleList.Find(o => o.nombre == nombre);

                /// Se devuelve una tarjeta o null
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                /// Si ocurre algun error
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public string Post(Roles role)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Roles.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();

                /// Se agrega un item con todos los atributos
                roleList.Add(new Roles()
                {
                    nombre = role.nombre,
                    descripcion = role.descripcion
                });

                /// Se reescribre el contenido
                jsonData = JsonConvert.SerializeObject(roleList);
                File.WriteAllText(filePath, jsonData);
                return "Added Succesfully!!!";
            }
            catch
            {
                /// Si ocurre algun error
                return "Something went wrong";
            }
        }

        /**
         * El metodo put actualiza una tarjeta
         * <returns> Un string de confirmacion
         */
        [Route("api/Roles/{nombre}")]
        [HttpPut]
        public string Put(Roles role)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Roles.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var roleList = JsonConvert.DeserializeObject<List<Roles>>(jsonData) ?? new List<Roles>();

                /// Se busca el rol para editarla
                foreach (Roles item in roleList)
                {
                    if(item.nombre == role.nombre)
                    {
                        item.descripcion = item.descripcion;
                    }
                }
                /// Se reescribre la informacion
                jsonData = JsonConvert.SerializeObject(roleList);
                File.WriteAllText(filePath, jsonData);
                return "Update Sucess!!!";
            }
            catch
            {
                /// Si ocurre algun error
                return "Something went wrong";
            }
        }
    }
}
