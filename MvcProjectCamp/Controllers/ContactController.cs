using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = cm.GetContactList();
       

             
            return View(contactValues);
        }

        public PartialViewResult MessageMenu()
        {
            return PartialView();
        }

       
        public ActionResult GetContactDetails(int id)
        {
            var contactValuesResults = cm.GetByContactId(id);

            return View(contactValuesResults);

        }
    }
}