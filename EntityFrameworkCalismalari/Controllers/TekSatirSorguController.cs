using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCalismalari.Contexts;

namespace EntityFrameworkCalismalari.Controllers
{
    public class TekSatirSorguController : Controller
    {
        SqlContext db=new SqlContext();
        public ActionResult Index()
        {
            //muşterileri listeler
            var iquarableListe = db.Customers;

            //liste tipinde dondurmek ıcın
            var liste = db.Customers.ToList();
           

            //where sorgusu ile cekmek
            var whereListe = db.Customers.Where(x => x.City == "İzmir" && x.CompanyName=="Yazilim");

            //orderby sorgusu ile cekmek
            var orderListe = db.Customers.Where(x => x.City == "İzmir" && x.CompanyName == "Yazilim").OrderBy(x=>x.CompanyName);

            //orderby descending sorgusu ile cekmek
            var descListe = db.Customers.Where(x => x.City == "İzmir" && x.CompanyName == "Yazilim").OrderByDescending(x => x.CompanyName);

            //select ile  istenilen bilgierli almak ıcin
            var selectListe = db.Customers.Where(x => x.City == "İzmir" && x.CompanyName == "Yazilim").OrderByDescending(x => x.CompanyName).Select(x=>new
            {
                x.CustomerID,x.City,x.Country

            });


            return View();
        }

        public void Include()
        {
            //mustei id si veysel olanın siparısleırnıde getirir
            var deger = db.Customers.Where(x=>x.CustomerID=="Veysel").Include("Orders");

            foreach (var item in deger)
            {
                var sonuc = item.City + " " + item.CompanyName + " " + item.Orders.Count+" "+item.Orders.Count;
            }

            foreach (var item in deger)
            {
                foreach (var order in item.Orders)
                {
                    var orderslar = order.ShipCity;
                }
            }
        }
    }
}