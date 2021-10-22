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
    public class AbilityController : Controller
    {
        private MyAboutManager ma = new MyAboutManager(new EfMyAbout());
        // GET: Ability
        public ActionResult Index()
        {
            var MyAboutValues = ma.GetMyAboutList();
           

            return View(MyAboutValues);
        }
    }
}