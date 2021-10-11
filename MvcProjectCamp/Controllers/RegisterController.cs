using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class RegisterController : Controller
    {
        AdminManager ad = new AdminManager(new EfAdminDal());

        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {

            string[] Roles = {"A", "B", "C"};
            
            List<SelectListItem> valueAdminRole = (from c in Roles //Listeleme 
                select new SelectListItem()
                {
                    Text = c.ToString(),
                    Value = c.ToString()

                }).ToList();

            ViewBag.adminrole = valueAdminRole;

            return View();
        }


        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            /*SHA1 ile Hash İşlemi*/

            SHA1 sha2 = new SHA1CryptoServiceProvider();
            string hashadminuser = admin.AdminUserName;
            string hashpassword = admin.AdminPassword;

            string resultPw = Convert.ToBase64String(sha2.ComputeHash(Encoding.UTF8.GetBytes(hashpassword)));

     
            admin.AdminPassword = resultPw;
           

            ad.AdminAddBl(admin);

            return RedirectToAction("Index","Login");
        }
    }
}