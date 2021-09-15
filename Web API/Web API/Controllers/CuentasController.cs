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
    public class CuentasController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var filePath = @"DataBase\Accounts.json";
            var response = JsonConvert.DeserializeObject(File.ReadAllText(filePath));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("api/Cuentas/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var filePath = @"DataBase\Accounts.json";
                var jsonData = File.ReadAllText(filePath);
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();
                Cuentas item = cuentasList.Find(o => o.id == id);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
        public string Post(Cuentas cliente)
        {
            try
            {
                var filePath = @"DataBase\Accounts.json";
                var jsonData = File.ReadAllText(filePath);
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();
                cuentasList.Add(new Cuentas()
                {
                    numeroCuenta = cliente.numeroCuenta,
                    descripcionCuenta = cliente.descripcionCuenta,
                    cliente = cliente.cliente,
                    tipoCuenta = cliente.tipoCuenta,
                    montoDisponible = cliente.montoDisponible,
                    moneda = cliente.moneda
                });
                jsonData = JsonConvert.SerializeObject(cuentasList);
                File.WriteAllText(filePath, jsonData);
                return "Added succesfully!!!";
            }
            catch
            {
                return "Something went wrong...";
            }
        }

        [Route("api/Cuentas/{id}")]
        [HttpPut]
        public string Put(Cuentas cuenta)
        {
            try
            {
                var filePath = @"DataBase\Accounts.json";
                var jsonData = File.ReadAllText(filePath);
                var cuentasList = JsonConvert.DeserializeObject<List<Cuentas>>(jsonData) ?? new List<Cuentas>();
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
                jsonData = JsonConvert.SerializeObject(cuentasList);
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
