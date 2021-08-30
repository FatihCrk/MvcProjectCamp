using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class DraftController : Controller
    {
        DraftManager df = new DraftManager(new EfDraftDal());



        // GET: Draft
        public ActionResult Index()
        {
            var draftValue = df.GetDraftList();
            return View(draftValue);
        }


        public ActionResult SendDraft(Draft d)
        {
            d.MessageDate = DateTime.Now;
            df.DraftAddBl(d);

            return RedirectToAction("NewMessage","Message");
        }




        [HttpGet]
        public ActionResult EditDraft(int id)
        {

            List<SelectListItem> valueDraft = (from c in df.GetDraftList() //Listeleme 
                select new SelectListItem()
                {
                    Text = c.Subject,
                    Value = c.MessageContent.ToString()

                }).ToList();
            ViewBag.vlc = valueDraft;
            var draftValue = df.GetByDraftId(id);

            return View(draftValue);
        }

        [HttpPost]
        public ActionResult EditDraft(Draft h)
        {

            df.DraftUpdate(h);

            return RedirectToAction("Index");
        }


    }

}