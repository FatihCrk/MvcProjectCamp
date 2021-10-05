using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Web.Security;
using DataAccessLayer.EntityFramework;

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
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserInfo != null )
            {
                FormsAuthentication.SetAuthCookie(adminuserInfo.AdminUserName,false); // Kalıcı coockie oluşsun mu false;
                Session["AdminUserName"] = adminuserInfo.AdminUserName; 
                return RedirectToAction("Index", "Gallery");
            }


            return RedirectToAction("Page404", "ErrorPages");
        }
    }
}