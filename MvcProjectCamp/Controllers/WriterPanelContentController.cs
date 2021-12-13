using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent


        ContentManager cm = new ContentManager(new EfContentDal());
        private Context c = new Context();


        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
          
            var contentValues = cm.GetListByWriterId(writerIdInfo);
            return View(contentValues);
        }

         [HttpGet]
        public ActionResult AddContent(int id)
        {

            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           string mailAccount = (string)Session["WriterMail"];

            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mailAccount).Select(y => y.WriterId).FirstOrDefault();

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writerIdInfo;
            p.ContentStatus = true;

            cm.ContentAddBl(p);

            return RedirectToAction("MyContent");
        }




    }
}