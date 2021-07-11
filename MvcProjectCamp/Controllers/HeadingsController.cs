using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{


    public class HeadingsController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal()); // GET: Headings
        public ActionResult HeadingsList()
        {
            var headingValues = hm.GetHeadingList();

            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {

            List<SelectListItem> valueCategory = (from c in cm.GetCategoryList() //Listeleme 
                                                  select new SelectListItem()
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()

                                                  }).ToList();

            List<SelectListItem> valueWriter = (from w in wm.GetWriterList()
                                                select new SelectListItem()
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurName,
                                                    Value = w.WriterId.ToString()

                                                }).ToList();

            ViewBag.vlw = valueWriter;
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBl(h);
            return RedirectToAction("HeadingsList");
            
        }



       


        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory = (from c in cm.GetCategoryList() //Listeleme 
                select new SelectListItem()
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()

                }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetByHeadingId(id);

            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {

            hm.HeadingUpdate(h);

            return RedirectToAction("HeadingsList");
        }







    }
}



