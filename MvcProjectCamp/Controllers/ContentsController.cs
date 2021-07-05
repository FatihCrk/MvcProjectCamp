using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    public class ContentsController : Controller
    {
        ContentManager cntm = new ContentManager(new EfContentDal());

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cntm.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}