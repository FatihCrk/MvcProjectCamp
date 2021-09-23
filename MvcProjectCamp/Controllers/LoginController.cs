using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            Context c = new Context();
            var adminuserInfo = c.Admins.FirstOrDefault(x =>
                x.AdminUserName == a.AdminUserName && x.AdminPassword == a.AdminPassword);
            if (adminuserInfo != null )
            {
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Page404","ErrorPages");

            }

            return View();
        }
    }
}