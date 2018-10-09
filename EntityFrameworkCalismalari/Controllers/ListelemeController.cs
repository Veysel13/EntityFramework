using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCalismalari.Contexts;
using EntityFrameworkCalismalari.Entities;
using Microsoft.ApplicationInsights.Web;

namespace EntityFrameworkCalismalari.Controllers
{
    public class ListelemeController : Controller
    {
        SqlContext db=new SqlContext();
      
        public ActionResult Liste()
        {
            //listeler ıquarable olarak doner default olarak
            IQueryable<Customer> result = from c in db.Customers
                select c;

            //sadece istedigim lanalrı almak ıcın
            //tek alan cektıgımde foreach de direk item ile ulaşabilirim
            var result1 = from c in db.Customers
                select c.ContactName;


            //birden cok  istedigim alanalrı almak ıcın
            var result2 = from c in db.Customers
                select new {c.ContactName,c.CompanyName,c.City};

            //liste tipinden dondureceksem tolist demem gerekir
            List<Customer> result4 = (from c in db.Customers
                select c).ToList();


            //kendimiz bir tip yapmak ıstersek
            var result5 = from c in db.Customers
                select new Musteri{ Ulke=c.ContactName, Sirket=c.CompanyName, Sehir=c.City };

            //seklinde ulasım saglayacabıliriz
            foreach (var item in result5)
            {
                var deger=item.Ulke+" "+item.Sehir;

            }
            return View(result);
        }

        public ActionResult Where()
        {
            //where sorguları ile veri cekebilirz
            IQueryable<Customer> result=from c in db.Customers
                where c.Country=="UK"
                select c;

            IQueryable<Customer> result2 = from c in db.Customers
                where c.Country == "UK" && c.City=="London"
                select c;

            IQueryable<Customer> result3 = from c in db.Customers
                where c.Country == "UK" || c.City == "London"
                select c;
            return View();
        }

        public ActionResult GroupBy()
        {
            //group by ile sorgu
           var result = from c in db.Customers group c by c.Country into g select g;

            foreach (var group in result)
            {
                //ulke isimlerine göre guruplamıstım 
                //her bır ulke ısmını getirir
                var ulke = group.Key;
            }

            //birden cok kolona gore guruplama
            var result2 = from c in db.Customers group c by new{ c.Country,c.City} into g select g;

            //birden cok kolona gore guruplayıp istegımız veri gurubuna ulasma
            var result3 = from c in db.Customers group c by new { c.Country, c.City } into g select new
            {
                Sehir=g.Key.City,
                Ulke=g.Key.Country,
                Adet=g.Count()
            };

            //ulkesı turkıye olup sehrı ızmır olan kac musterımız oldugunu adet bılgısınde gorebılırız
            foreach (var group in result3)
            {
                var deger = group.Sehir + " " + group.Ulke + " " + group.Adet;
            }

            return View();
        }

        public ActionResult OrderBy()
        {
            //order by ile verileri sıralamak ıstersek
            //sehre  gore sıralar daha sonra gelen verileri ulkeye gore sırlar ıkılı karsılastırma

            var result = from c in db.Customers
                orderby c.City,c.ContactName
                select c;

            //tersten sıralama metodu ekleyebılrız
            var result2 = from c in db.Customers
                orderby c.City, c.ContactName
                    descending
                select c;
            return View();
        }

        public void Join()
        {

            //bu join işlemlerinde siparisi olan musterileri bize getirir siparisi olmayan musterileri getirmez


            //joın ıfadesi ile kolanları birleştirip istediğim kolonları alabılırım
            var result = from c in db.Customers
                join o in db.Orders
                    on c.CustomerID equals o.CustomerID
                    orderby o.CustomerID
                select new {c.CustomerID,c.ContactName,o.ShipCity,o.ShipCountry };

            foreach (var item in result)
            {
                var deger = item.CustomerID + " " + item.ContactName + " " + item.ShipCountry + " " + item.ShipCity;

            }



            //birden cok ıfade ile join ıfadesi ile kolanları birleştirip istediğim kolonları alabılırım
            var result2 = from c in db.Customers
                join o in db.Orders
                    on
                    new{c.CustomerID,Sehir=c.City}
                    equals
                    new {o.CustomerID,Sehir=o.ShipCity}
                orderby o.CustomerID
                select new { c.CustomerID, c.ContactName, o.ShipCity, o.ShipCountry };

            foreach (var item in result)
            {
                var deger = item.CustomerID + " " + item.ContactName + " " + item.ShipCountry + " " + item.ShipCity;
            }
        }



        public void LeftJoin()
        {
            //siparisi olmayan  musterileri bulmak ıcın yanı sal tabloda olup da  sag tabloda ilişkisi olmayan veriler
            //siparisi olmayan musterieler i getirmek için
            var result = from c in db.Customers
                join o in db.Orders
                    on c.CustomerID equals o.CustomerID into temp
                from co in temp.DefaultIfEmpty()
                where temp.Count()==0
                select new{c.CustomerID,c.ContactName,c.CompanyName};



            //siparsi olan musterileri getirmek için de
            var result2 = from c in db.Customers
                join o in db.Orders
                    on c.CustomerID equals o.CustomerID into temp
                from co in temp.DefaultIfEmpty()
                where temp.Count() > 0
                select new { c.CustomerID, c.ContactName, c.CompanyName };

            foreach (var item in result2)
            {
                var deger = item.CustomerID + " " + item.ContactName + " " + item.CompanyName;
            }
        }

       
    }
    public class Musteri
    {
        public string Ulke { get; internal set; }
        public string Sirket { get; internal set; }
        public string Sehir { get; internal set; }
    }

   
}