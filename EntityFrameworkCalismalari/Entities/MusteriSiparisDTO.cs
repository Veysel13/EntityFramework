using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityFrameworkCalismalari.Entities
{
    //bu taplonun veri tababınında oluşmasını istemiyorsm
    [ComplexType]
    public class MusteriSiparisDTO
    {
        public string MusteriId { get; set; }
        public string SiparisId { get; set; }
    }
}