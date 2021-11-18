using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Web.Security;
using BusinessLayer.Concrete;
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

            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string hashAdminUser = p.AdminUserName;
            string hashPassword = p.AdminPassword;

           
            string resultPw = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(hashPassword)));
            p.AdminPassword = resultPw;


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
        [HttpGet]
        public ActionResult WriterLogin() 
        {

            return View();

        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {

            SHA1 sha1 = new SHA1CryptoServiceProvider();
         
            string hashPassword = p.WriterPassword;


            string resultPw = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(hashPassword)));
            p.WriterPassword = resultPw;


            Context c = new Context();
            var writerUserInfo = c.Writers.FirstOrDefault(x =>  x.WriterPassword == p.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterPassword, false); // Kalıcı coockie oluşsun mu false;
                Session["WriterUserName"] = writerUserInfo.WriterName;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            return RedirectToAction("Page404", "ErrorPages");

        }


    }
}