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
    /**
     * En esta clase se encuentran todos los metodos que se pueden hacer desde el controlador de Clientes
     * Esto incluye:
     * - Get genera
     * - Get individual
     * - Post
     * - Put
     */
    public class ClientesController : ApiController
    {
        /**
         *El metodo get devuelte todas los clientes
         <returns>Respuesta del api en formato json de todo el contenido
         */
        public HttpResponseMessage Get()
        {
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /**
         * El metodo get individual devuelve un solo item segun la cedula del cliente
         * <returns>Respuesta del api en formato json de un solo item
         */
        [Route("api/Clientes/{cedulaCliente}")]
        [HttpGet]
        public HttpResponseMessage Get(string cedulaCliente)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Clients.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();

                /// Se busca una tarjeta en especifico
                Clientes item = clientList.Find(o => o.cedulaCliente == cedulaCliente);

                /// Se devuelve una tarjeta o null
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                /// Si ocurre algun error
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /**
         * El metodo post agrega un nuevo cliente
         * <returns> Un string de confirmacion
         */
        public string Post(Clientes role)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Clients.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();
                
                /// Se agrega un cliente nuevo
                clientList.Add(new Clientes()
                {
                    nombreCliente = role.nombreCliente,
                    direccionCliente = role.direccionCliente,
                    telefonoCliente = role.telefonoCliente,
                    usuarioCliente = role.usuarioCliente,
                    contrasenaCliente = role.contrasenaCliente,
                    ingresoCliente = role.ingresoCliente,
                    tipoCliente = role.tipoCliente
                });

                /// Se reescribre el contenido
                jsonData = JsonConvert.SerializeObject(clientList);
                File.WriteAllText(filePath, jsonData);
                return "Added succesfully!!!";
            }
            catch
            {
                /// Si ocurre algun error
                return "Something went wrong...";
            }
        }

        /**
         * El metodo put actualiza un cliente
         * <returns> Un string de confirmacion
         */
        [Route("api/Clientes/{cedulaCliente}")]
        [HttpPut]
        public string Put(Clientes cliente)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Clients.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();

                /// Se busca la tarjeta para editarla
                foreach (Clientes item in clientList)
                {
                    if(item.cedulaCliente == cliente.cedulaCliente)
                    {
                        item.nombreCliente = cliente.nombreCliente;
                        item.direccionCliente = cliente.direccionCliente;
                        item.telefonoCliente = cliente.telefonoCliente;
                        item.usuarioCliente = cliente.usuarioCliente;
                        item.contrasenaCliente = cliente.contrasenaCliente;
                        item.ingresoCliente = cliente.ingresoCliente;
                        item.tipoCliente = cliente.tipoCliente;
                    }
                }

                /// Se reescribre la informacion
                jsonData = JsonConvert.SerializeObject(clientList);
                File.WriteAllText(filePath, jsonData);
                return "Updated succesfully!!!";
            }
            catch
            {
                /// Si ocurre algun error
                return "Something went wrong...";
            }
        }
    }
}
