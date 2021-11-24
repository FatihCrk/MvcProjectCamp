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
        private Context cn = new Context();
        public ActionResult MyContent()
        {
            int id;
            id = 34;
            var contentValues = cm.GetListByWriter(id);

           

            return View(contentValues);
        }








    }
}