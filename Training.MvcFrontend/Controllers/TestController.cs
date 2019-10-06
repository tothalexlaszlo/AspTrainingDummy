using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Training.MvcFrontend.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HtmlHelper()
        {
            return View();
        }

        public ActionResult PartialTest()
        {
            return View();
        }
    }
}