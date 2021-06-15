using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;


namespace MvcProjectCamp.Controllers
{
    public class WritersController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Writer


        public ActionResult WritersList()
        {
            var writerValues = wm.GetWriterList();
            return View(writerValues);
        }
    }
}