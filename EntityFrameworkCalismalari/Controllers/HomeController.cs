using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCalismalari.Contexts;
using EntityFrameworkCalismalari.Entities;

namespace EntityFrameworkCalismalari.Controllers
{
    public class HomeController : Controller
    {
        //context oluşturarak veri tabnı baglantımızı açtık
        SqlContext db = new SqlContext();
        public ActionResult Index()
        {
            SqlContext db=new SqlContext();

            return View(db.Orders.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CustomerList()
        {
            


            return View(db.Customers);
        }


        public ActionResult CustomerAdd()
        {
           Customer model=new Customer
           {
               City = "İzmir",
               CompanyName = "Torbalı",
               ContactName = "veysel@gmail.com",
               Country ="Turkiye"
           };
            db.Customers.Add(model);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        public ActionResult OrderAdd()
        {
            Customer customer=db.Customers.Find(1);
           
            customer.Orders.Add(
                new Order
                {
                    OrderID = 1,
                    OrderDate = DateTime.Now,
                    ShipCity = "Ankara",
                    ShipCountry = "Türkiye"
                });
            db.SaveChanges();
            
            return RedirectToAction("CustomerList");
        }

        public ActionResult OrderDelete()
        {
            Order order = db.Orders.Find(1);
            db.Orders.Remove(order);
            db.SaveChanges();

            return RedirectToAction("CustomerList");
        }


        public ActionResult CuıstomerUpdate()
        {
            Customer customer = db.Customers.Find(1);
            customer.Country = "Turkey";
            customer.City = "Ankara";
            db.SaveChanges();

            return RedirectToAction("CustomerList");
        }

    }
}