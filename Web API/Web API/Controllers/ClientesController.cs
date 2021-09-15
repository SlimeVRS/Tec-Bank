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
    public class ClientesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var filePath = @"DataBase\Clients.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/Clientes/{cedulaCliente}")]
        [HttpGet]
        public HttpResponseMessage Get(string cedulaCliente)
        {
            try
            {
                var filePath = @"DataBase\Clients.json";
                var jsonData = File.ReadAllText(filePath);
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();
                Clientes item = clientList.Find(o => o.cedulaCliente == cedulaCliente);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        public string Post(Clientes role)
        {
            try
            {
                var filePath = @"DataBase\Clients.json";
                var jsonData = File.ReadAllText(filePath);
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();
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

                jsonData = JsonConvert.SerializeObject(clientList);
                File.WriteAllText(filePath, jsonData);
                return "Added succesfully!!!";
            }
            catch
            {
                return "Something went wrong...";
            }
        }

        [Route("api/Clientes/{cedulaCliente}")]
        [HttpPut]
        public string Put(Clientes cliente)
        {
            try
            {
                var filePath = @"DataBase\Clients.json";
                var jsonData = File.ReadAllText(filePath);
                var clientList = JsonConvert.DeserializeObject<List<Clientes>>(jsonData) ?? new List<Clientes>();
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
                jsonData = JsonConvert.SerializeObject(clientList);
                File.WriteAllText(filePath, jsonData);
                return "Updated succesfully!!!";
            }
            catch
            {
                return "Something went wrong...";
            }
        }
    }
}
