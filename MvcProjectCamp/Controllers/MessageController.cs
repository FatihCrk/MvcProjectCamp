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

        Context context = new Context();

        // GET: Message
        public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);

            var messageValueNumber = mm.GetListInbox(p).Count;
            ViewBag.messageValue = messageValueNumber;

            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == p).Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

            return View(messageList);


        }

        public ActionResult Sendbox(string p)
        {
            var messageList = mm.GetListSendbox(p);


            var messageValueNumber = mm.GetListInbox(p).Count;
            ViewBag.messageValue = messageValueNumber;

            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == p).Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

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
            HttpUtility utility = new HttpUtility();



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

                    //MvcHtmlString data = MvcHtmlString.Create( message.MessageContent);

                    //message.MessageContent = data.ToString();


                    string data = Server.HtmlEncode(message.MessageContent);
                    message.MessageContent = data;


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

            getDraftDetails.MessageContent = HttpUtility.HtmlDecode(getDraftDetails.MessageContent);

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
        public ActionResult EditDraft(Message message, string buttons)
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
                    message.MessageContent = HttpContext.Server.HtmlEncode(message.MessageContent);

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


        public ActionResult IsRead(int id)
        {
            var result = mm.GetById(id);
            if (result.IsReadStatus == true)
            {
                result.IsReadStatus = false;
            }
            else if (result.IsReadStatus == false)
            {
                result.IsReadStatus = true;
            }

            mm.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }




    }
}