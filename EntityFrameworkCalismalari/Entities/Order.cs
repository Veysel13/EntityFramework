using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }

        public  Customer Customer { get; set; }

    }
}