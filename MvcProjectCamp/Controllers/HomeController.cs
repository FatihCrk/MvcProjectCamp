using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //veriler listelenirken Index metodu ile listeleniyor. Bu metotların View tarafında karşılığı olmak zorunda.
        {
            return View();
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

        public ActionResult TestMethod()
        {
            

            return View();
        }
    }
}