using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentsController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContentByHeading()
        {
            return View();
        }
    }
}