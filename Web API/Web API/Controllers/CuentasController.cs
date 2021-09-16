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
     * En esta clase se encuentran todos los metodos que se pueden hacer desde el controlador de Cuentas
     * Esto incluye:
     * - Get genera
     * - Get individual
     * - Post
     * - Put
     */
    public class CuentasController : ApiController
    {
        /**
         *El metodo get devuelte todas las cuentas
         <returns>Respuesta del api en formato json de todo el contenido
         */
        public HttpResponseMessage Get()
        {
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /**
         * El metodo get individual devuelve un solo item segun el id de la cuenta
         * <returns>Respuesta del api en formato json de un solo item
         */
        [Route("api/Cuentas/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Accounts.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();

                /// Se busca una cuenta en especifico
                Cuentas item = cuentasList.Find(o => o.id == id);

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
         * El metodo post agrega una nueva cuenta
         * <returns> Un string de confirmacion
         */
        public string Post(Cuentas cliente)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Accounts.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();

                /// Se agrega un item con todos los atributos 
                cuentasList.Add(new Cuentas()
                {
                    numeroCuenta = cliente.numeroCuenta,
                    descripcionCuenta = cliente.descripcionCuenta,
                    cliente = cliente.cliente,
                    tipoCuenta = cliente.tipoCuenta,
                    montoDisponible = cliente.montoDisponible,
                    moneda = cliente.moneda
                });

                /// Se reescribre el contenido
                jsonData = JsonConvert.SerializeObject(cuentasList);
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
         * El metodo put actualiza una tarjeta
         * <returns> Un string de confirmacion
         */
        [Route("api/Cuentas/{id}")]
        [HttpPut]
        public string Put(Cuentas cuenta)
        {
            try
            {
                /// Directorio en donde se encuentra la base de datos
                var filePath = @"F:\Progras\Tec-Bank\Web API\Web API\DataBase\Accounts.json";

                /// Se guarda el contenido como un string
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();

                /// Se busca la cuenta para editarla
                foreach (Cuentas item in cuentasList)
                {
                    if (item.id == cuenta.id)
                    {
                        item.numeroCuenta = cuenta.numeroCuenta;
                        item.descripcionCuenta = cuenta.descripcionCuenta;
                        item.cliente = cuenta.cliente;
                        item.tipoCuenta = cuenta.tipoCuenta;
                        item.montoDisponible = cuenta.montoDisponible;
                        item.moneda = cuenta.moneda;
                    }
                }
                /// Se reescribre la informacion
                jsonData = JsonConvert.SerializeObject(cuentasList);
                File.WriteAllText(filePath, jsonData);
                return "Updated success!!!";
            }
            catch
            {
                /// Si ocurre algun error
                return "Something went wrong";
            }
        }
    }
}
