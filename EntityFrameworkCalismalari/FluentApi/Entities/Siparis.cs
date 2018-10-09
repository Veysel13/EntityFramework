using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.FluentApi.Entities
{
    public class Siparis
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }

        public Musteri Musteri { get; set; }
    }
}