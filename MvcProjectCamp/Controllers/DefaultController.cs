using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default



        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        ContentManager cm = new ContentManager(new EfContentDal());

        
        public ActionResult Headings()
        {
            

            var headingList = hm.GetHeadingList();

            return View(headingList);

        }
      
        public PartialViewResult Index(int id = 0)
        {
            var contentList = cm.GetListByHeadingId(id);

            return PartialView(contentList);
        }

        public ActionResult AllHeading()
        {
            var headingsList = hm.GetHeadingList();

            return View(headingsList);
        }
    }
}