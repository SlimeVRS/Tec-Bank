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
    public class TarjetaCreditoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            Console.WriteLine("This is a get response");
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/TarjetaCredito/{numeroTarjeta}")]
        [HttpGet]
        public HttpResponseMessage Get(string numeroTarjeta)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
                TarjetaCredito item = cardList.Find(o => o.numeroTarjeta == numeroTarjeta);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        public string Post(TarjetaCredito card)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
                cardList.Add(new TarjetaCredito()
                {
                    nombre = card.nombre,
                    numeroTarjeta = card.numeroTarjeta,
                    tipoTarjeta = card.tipoTarjeta,
                    fecha = card.fecha,
                    cvv = card.cvv,
                    montoDisponible = card.montoDisponible
                });

                jsonData = JsonConvert.SerializeObject(cardList);
                File.WriteAllText(filePath, jsonData);
                return "Added succesfully!!!";
            }
            catch (Exception)
            {
                return "Something went wrong...";
            }
        }

        [Route("api/TarjetaCredito/{numeroTarjeta}")]
        [HttpPut]
        public string Put(TarjetaCredito card)
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\DataBase\Cards.json";
                var jsonData = File.ReadAllText(filePath);
                var cardList = JsonConvert.DeserializeObject<List<TarjetaCredito>>(jsonData) ?? new List<TarjetaCredito>();
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
                jsonData = JsonConvert.SerializeObject(cardList);
                File.WriteAllText(filePath, jsonData);
                return "Updated success!!!";
            }
            catch
            {
                return "Something went wrong";
            }
        }
    }
}
