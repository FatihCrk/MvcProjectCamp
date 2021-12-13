using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        Context context = new Context();

        // GET: WriterPanelMessage
     

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterMail).FirstOrDefault();


            var messageList = mm.GetListInbox(writerIdInfo);
            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == "f.cirak@gmail.com").Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

            return View(messageList);


        }

        public PartialViewResult MessageListMenu(string p)
        {
            var messageValueNumber = mm.GetListInbox(p).Count;
            ViewBag.messageValue = messageValueNumber;

            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == "f.cirak@gmail.com").Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

            return PartialView();
        }

        public ActionResult Sendbox(string p)
        {
            var messageList = mm.GetListSendbox(p);
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



    }
}