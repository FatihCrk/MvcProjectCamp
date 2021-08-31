using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.FluentValidation;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal()); 
        MessageValidator messageValidator = new MessageValidator();
        ContactManager cm = new ContactManager(new EfContactDal());


        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            var messageValueNumber= mm.GetListInbox().Count;
            ViewBag.messageValue = messageValueNumber;

            return View(messageList);




        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();

        }



        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();

        }

     

        [HttpPost]
        public ActionResult MessageOfSendDraft(Message message, string button)
        {
            
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.SenderMail = "admin@gmail.com";
                message.isDraft = true;

                return RedirectToAction("Draft");


            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
           
            return View();


        }

        [HttpGet]
        public ActionResult EditDraft(int id)
        {

            

            return View();
        }





    }
}