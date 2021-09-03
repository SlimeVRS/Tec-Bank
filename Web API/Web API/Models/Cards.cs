using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Cards
    {
        public String cardNumber { get; set; }
        public String cardType { get; set; }
        public String cardExpiryDate { get; set; }
        public String cardSecureCode { get; set; }
        public String cardBalance { get; set; }
    }
}