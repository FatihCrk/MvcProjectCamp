using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{    [AllowAnonymous]
    public class ErrorPagesController : Controller
    {
        // GET: ErrorPages
        public ActionResult Page403()
        {
            Response.StatusCode = 403;

            Response.TrySkipIisCustomErrors = true;  //Hata kodunu atlama

            return View();
        }
        [HttpGet]
        public ActionResult Page404()
        {
            Response.StatusCode = 404;

            Response.TrySkipIisCustomErrors = true;  

            return View();
        }

     
        [HttpGet]
        public ActionResult Page401()
        {
            Response.StatusCode = 401;

            Response.TrySkipIisCustomErrors = true;  

            return View();
        }
    }
}