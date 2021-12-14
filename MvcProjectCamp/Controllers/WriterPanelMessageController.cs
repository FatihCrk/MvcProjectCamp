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
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        Context context = new Context(); //Mesaj Sayısı için

        // GET: WriterPanelMessage
     

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
         


            var messageList = mm.GetListInbox(p);
            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == p);
            ViewBag.inboxMessageResult = inboxMessageCount.Count();

            return View(messageList);


        }

        public PartialViewResult MessageListMenu(string p)
        {
             p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterMail).FirstOrDefault();

            var messageValueNumber = mm.GetListInbox(p).Count;
            ViewBag.messageValue = messageValueNumber;

            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == p );
            ViewBag.inboxMessageResult = inboxMessageCount.Where(x=>x.IsReadStatus == false ).Count();

            var sendboxMessageCount = context.Messages.Where(x => x.SenderMail == p);
            ViewBag.sendboxMessageResult = sendboxMessageCount.Where(x => x.IsReadStatus == false).Count();


            return PartialView();
        }

        public ActionResult Sendbox(string p)
        {
             p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterMail).FirstOrDefault();




            var messageList = mm.GetListSendbox(writerIdInfo);


           
       
            return View(messageList);
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

            string sender = (string)Session["WriterMail"];


            if (results.IsValid)
            {
                if (buttons == "send")
                {
                    message.SenderMail = sender;
                    message.isDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBl(message);
                    return RedirectToAction("Sendbox");

                }
                else if (buttons == "draft")
                {
                    message.SenderMail = sender;
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




        public ActionResult DraftList()
        {

            var draftList = mm.GetTheDraftMessage();


            return View(draftList);

        }





    }
}