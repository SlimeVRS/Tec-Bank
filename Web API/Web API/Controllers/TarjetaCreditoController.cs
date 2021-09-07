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
            var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\Web API\Web API\DataBase\Cards.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public string Post(TarjetaCredito card   )
        {
            try
            {
                var filePath = @"C:\Users\Brandon\Desktop\Tec-Bank\Web API\Web API\DataBase\Cards.json";
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
    }
}
