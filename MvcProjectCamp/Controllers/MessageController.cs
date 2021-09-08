using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();


        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            var messageValueNumber = mm.GetListInbox().Count;
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
        public ActionResult NewMessage(Message message, string buttons)
        {
            MessageValidator messageValidator = new MessageValidator();
            ValidationResult results = messageValidator.Validate(message);


            if (results.IsValid)
            {
                if (buttons == "send")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBl(message);
                    return RedirectToAction("Sendbox");
                }
               else if (buttons == "draft")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBl(message);
                    return RedirectToAction("DraftList");
                    
                }
              

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

        public ActionResult GetMessageDetails(int id)
        {


            var getMessageDetails = mm.GetById(id);


            return View(getMessageDetails);
        }


        public ActionResult GetDraftDetails(int id)
        {


            var getDraftDetails = mm.GetById(id);



            return View(getDraftDetails);
        }






        public ActionResult DraftList()
        {

            var draftList = mm.GetTheDraftMessage();

            return View(draftList);

        }

        [HttpGet]
        public ActionResult EditDraft(int id)
        {
            var draftValue = mm.GetById(id);

            return View(draftValue);
        }

        [HttpPost]
        public ActionResult EditDraft(Message message,string buttons)
        {


            MessageValidator messageValidator = new MessageValidator();
            ValidationResult results = messageValidator.Validate(message);


            if (results.IsValid)
            {
                if (buttons == "draft")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageUpdate(message); 
                    
                    return RedirectToAction("DraftList");

                }

               else if (buttons == "send")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageUpdate(message);
                    return RedirectToAction("Sendbox");
                }
                
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
    }
}