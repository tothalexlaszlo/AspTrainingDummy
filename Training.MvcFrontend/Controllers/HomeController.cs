using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.MvcFrontend.Filters;

namespace Training.MvcFrontend.Controllers
{
    //[OfflineFilter] // ha itt van a FilterAttribute akkor az adott Controller összes Actionjére igaz.
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // ha itt van a filterattribute, csak az adott Action-n fut le [OfflineFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Offline()
        {
            return View();
        }
    }
}