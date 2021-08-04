using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class AboutsController : Controller
    {
        AboutManager abm = new AboutManager( new EfAboutDal());
        // GET: Abouts
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]   
        public ActionResult AddAbout()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult AddAbout(About a)
        {
            abm.AboutAddBl(a);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}