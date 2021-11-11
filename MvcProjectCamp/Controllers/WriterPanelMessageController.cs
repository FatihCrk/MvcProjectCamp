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
            var messageList = mm.GetListInbox();

            var messageValueNumber = mm.GetListInbox().Count;
            ViewBag.messageValue = messageValueNumber;

            var inboxMessageCount = context.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count();
            ViewBag.inboxMessageResult = inboxMessageCount;

            return View(messageList);


        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }







    }
}