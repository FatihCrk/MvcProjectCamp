using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager  cm= new ContactManager(new EfContactDal());
    
        // GET: Message
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox();

            var messageValueNumber = mm.GetListInbox().Count;
            ViewBag.messageValue = messageValueNumber;

            return View(messageList);




        }

        public ActionResult Sendbox( )
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }
          





    }
}