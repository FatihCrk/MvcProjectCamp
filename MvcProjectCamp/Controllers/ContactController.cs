using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        Context context = new Context();
        
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = cm.GetContactList();
       

             
            return View(contactValues);
        }

        public PartialViewResult MessageMenu()
        {
            var contactMessageCount = context.Contacts.Count();
            ViewBag.contactMessageResult = contactMessageCount;


            var inboxMessageCount = context.Messages.Where(x=>x.ReceiverMail == "admin@gmail.com").Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

            var draftMessageValueCount = context.Messages.Where(x => x.SenderMail == "admin@gmail.com" && x.isDraft == true).Count();
            ViewBag.draftMessageResult = draftMessageValueCount;
            return PartialView();
            
        }

       
        public ActionResult GetContactDetails(int id)
        {
            var contactValuesResults = cm.GetByContactId(id);

            return View(contactValuesResults);

        }

        

        
    }
}