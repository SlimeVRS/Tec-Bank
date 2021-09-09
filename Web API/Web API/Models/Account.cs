using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Account
    {
        public String accountNumber { get; set; }
        public String accountDescription { get; set; }
        public String accountCurrency { get; set; }
        public String accountType { get; set; }
        public String accountOwner { get; set; }
    }
}