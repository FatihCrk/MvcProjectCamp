using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent


        ContentManager cm = new ContentManager(new EfContentDal());
       
        public ActionResult MyContent(string p)
        {
            Context cn = new Context();
            p = (string)Session["WriterMail"];
            var writerIdInfo = cn.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
          
            var contentValues = cm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }








    }
}