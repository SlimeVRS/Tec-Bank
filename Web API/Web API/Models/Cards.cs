using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Cards
    {
        public String nombre { get; set; }
        public String numeroTarjeta { get; set; }
        public String tipoTarjeta { get; set; }
        public String fecha { get; set; }
        public String cvv { get; set; }
        public String montoDisponible { get; set; }
    }
}