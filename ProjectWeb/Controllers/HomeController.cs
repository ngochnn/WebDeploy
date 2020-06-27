using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectWeb.Models;

namespace ProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dbshopgameEntities db = new dbshopgameEntities();
            List<Product> listpro = db.Products.Take(10).ToList<Product>();
            return View(listpro);
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
    }
}