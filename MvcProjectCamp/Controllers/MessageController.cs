using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

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
        public ActionResult NewMessage(Message p)
        {
            return View();

        }

        //[HttpPost]
        public ActionResult MessageOfSendDraft(Message message, string tip, IFormCollection forms)
        {

            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                if (tip == "draft")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.isDraft = true;
                    mm.MessageAddBl(message);
                    return RedirectToAction("DraftList");
                }
            else if (tip == "sent")
                {
                    message.SenderMail = "admin@gmail.com";
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToLongDateString());
                    mm.MessageAddBl(message);
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

            return View("DraftList");
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

            return RedirectToAction("DraftList");
        }

        [HttpPost]
        public ActionResult EditDraft(Message message)
        {


            MessageValidator messageValidator = new MessageValidator();
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                mm.MessageUpdate(message);
                return RedirectToAction("DraftList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }



            return View("DraftList");

        }
    }
}