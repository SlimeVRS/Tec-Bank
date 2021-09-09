using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Clients
    {
        public String clientName { get; set; }
        public String clientId { get; set; }
        public String clientAddress { get; set; }
        public String clientPhone { get; set; }
        public String clientSalary { get; set; }
        public String clientType { get; set; }
    }
}