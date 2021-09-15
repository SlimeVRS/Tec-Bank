using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Cuentas
    {
        public int id { get; set; }
        public String numeroCuenta { get; set; }
        public String descripcionCuenta { get; set; }
        public String cliente { get; set; }
        public String tipoCuenta { get; set; }
        public String montoDisponible { get; set; }
        public String moneda { get; set; }
    }
}