using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class RegisterController : Controller
    {
        AdminManager ad = new AdminManager(new EfAdminDal()); 
        
        RoleManager rm = new RoleManager(new EfRoleDal());

        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
          
            
            List<SelectListItem> valueAdminRole = (from c in rm.GetRoleList() //Listeleme 
                select new SelectListItem()
                {
                    Text = c.Description,
                    Value = c.Name.ToString()


                }).ToList();

            ViewBag.adminrole = valueAdminRole;

           

            return View();
        }
       

        [HttpPost]
        public ActionResult Index(Admin admin )
        {

            /*SHA1 ile Hash İşlemi*/

          
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            admin.AdminStatus = true;
            string adminrole = admin.AdminRole;



            ad.AdminAddBl(admin);


            return RedirectToAction("Index","Login");
        }

        






    }
}