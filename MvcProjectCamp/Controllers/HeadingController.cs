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
    

    public class HeadingsController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        // GET: Headings
        public ActionResult HeadingLists()
        {
            var headingValues = hm.GetHeadingList();

            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
           
            return View();
        }

    }
}



