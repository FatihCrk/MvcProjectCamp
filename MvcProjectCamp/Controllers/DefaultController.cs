using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        private HeadingManager hm = new HeadingManager(new EfHeadingDal());


        public ActionResult Headings()
        {
            var headingList = hm.GetHeadingList();
            return View(headingList);

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}