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

    * En esta clase se encuentran todos los metodos que se pueden hacer desde el controlador de Tarjetas
    * Esto incluye:
    * - Get genera
    * - Get individual
    * - Post
    * - Put

    */
    public class TarjetaCreditoController : ApiController
    {
        /**
        *El metodo get devuelte todas las tarjetas
        <returns>Respuesta del api en formato json de todo el contenido
        */
        public HttpResponseMessage Get()
        {
            Console.WriteLine("This is a get response");
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        /**
        * El metodo get individual devuelve un solo item segun el numero de tarjeta
        * <returns>Respuesta del api en formato json de un solo item
        */
        [Route("api/TarjetaCredito/{numeroTarjeta}")]
        [HttpGet]
        public HttpResponseMessage Get(string numeroTarjeta)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
                
                /// Se busca una tarjeta en especifico
                TarjetaCredito item = cardList.Find(o => o.numeroTarjeta == numeroTarjeta);

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
        * El metodo post agrega una nueva tarjeta
        * <returns> Un string de confirmacion
        */
        public string Post(TarjetaCredito card)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
                
                /// Se agrega un item con todos los atributos
                cardList.Add(new TarjetaCredito()
                {
                    nombre = card.nombre,
                    numeroTarjeta = card.numeroTarjeta,
                    tipoTarjeta = card.tipoTarjeta,
                    fecha = card.fecha,
                    cvv = card.cvv,
                    montoDisponible = card.montoDisponible
                });

                /// Se reescribre el contenido
                jsonData = JsonConvert.SerializeObject(cardList);
                File.WriteAllText(filePath, jsonData);
                return "Added succesfully!!!";
            }
            catch (Exception)
            {
                /// Si ocurre algun error
                return "Something went wrong...";
            }
        }

        /**
        * El metodo put actualiza una tarjeta
        * <returns> Un string de confirmacion
        */
        [Route("api/TarjetaCredito/{numeroTarjeta}")]
        [HttpPut]
        public string Put(TarjetaCredito card)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);

                /// Se crea una lista para ser usada
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
                
                /// Se busca la tarjeta para editarla
                foreach (TarjetaCredito item in cardList)
                {
                    if(item.numeroTarjeta == card.numeroTarjeta)
                    {
                        item.nombre = card.nombre;
                        item.tipoTarjeta = card.tipoTarjeta;
                        item.fecha = card.fecha;
                        item.cvv = card.cvv;
                        item.montoDisponible = card.montoDisponible;
                    }
                }
                /// Se reescribre la informacion
                jsonData = JsonConvert.SerializeObject(cardList);
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
