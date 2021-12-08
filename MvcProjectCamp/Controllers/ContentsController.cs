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
      
        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cntm.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}