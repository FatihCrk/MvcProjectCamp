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
using CaptchaMvc.HtmlHelpers;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        private WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());


        // GET: Login
       
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Admin p)
        {

            //SHA1 sha1 = new SHA1CryptoServiceProvider();
            //string hashPassword = p.AdminPassword;


            //string resultPw = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(hashPassword)));
            //p.AdminPassword = resultPw;


            Context c = new Context();
            var adminuserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserInfo.AdminUserName, false); // Kalıcı coockie oluşsun mu false;
                Session["AdminUserName"] = adminuserInfo.AdminUserName;
                return RedirectToAction("Index", "Gallery");
            }





            return RedirectToAction("Page404", "ErrorPages");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult WriterLogin()
        {

            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {

            //SHA1 sha1 = new SHA1CryptoServiceProvider();

            //string hashPassword = p.WriterPassword;


            //string resultPw = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(hashPassword)));
            //p.WriterPassword = resultPw;



            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);


            var writerUserInfo = wm.GetWriter(p.WriterMail,p.WriterPassword);


            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false); // Kalıcı coockie oluşsun mu false;
                Session["WriterMail"] = writerUserInfo.WriterMail;



                // Code for validating the CAPTCHA  
                if (this.IsCaptchaValid("Karakterler eşleşmedi, lütfen tekrar deneyin..."))
                {
                    
                    return RedirectToAction("MyContent", "WriterPanelContent", p.WriterMail.ToString());
                    //WriterMail gönderimi "RedirectToAction (p.Writermail.ToString)"
                }



            }
            

            ViewBag.ErrorMessage = "Karakterler eşleşmedi, lütfen tekrar deneyin...";

            return RedirectToAction("WriterLogin", "Login");
            

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");

        }




    }
}