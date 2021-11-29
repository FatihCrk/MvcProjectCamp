using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
    


        // GET: WriterPanel
        

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {
           
            p = (string)Session["WriterMail"];
          var  writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();

          


            var myHeadingValues = hm.GetListByWriter(writerIdInfo);
            return View(myHeadingValues);
        }



        [HttpGet]
        public ActionResult NewHeading(string p)
        {
                          
            List<SelectListItem> valueCategory = (from c in cm.GetCategoryList() //Listeleme 
                                                  select new SelectListItem()
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()

                                                  }).ToList();
            @ViewBag.vlc = valueCategory;
            return View();
        }


        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {

            string m = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();
           
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writerIdInfo;
            p.HeadingStatus = true;

            hm.HeadingAddBl(p);


            return RedirectToAction("MyHeading");

        }
        [HttpGet]
        public ActionResult EditMyHeading(int id)
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
        public ActionResult EditMyHeading(Heading h)
        {

            string m = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == m).Select(y => y.WriterId).FirstOrDefault();

            h.WriterId = writerIdInfo;



            h.HeadingId = c.Headings.Where(x=>x.WriterId == h.WriterId).Select(y=>y.HeadingId).FirstOrDefault();

            hm.HeadingUpdate(h);

            return RedirectToAction("MyHeading");
        }



        public ActionResult DeleteHeading(int id)
        {

            var headingValue = hm.GetByHeadingId(id);

            switch (headingValue.HeadingStatus)
            {
                case true:
                    headingValue.HeadingStatus = false;
                    break;
                case false:
                    headingValue.HeadingStatus = true;
                    break;
            }


            hm.HeadingDelete(headingValue);

            return RedirectToAction("MyHeading");
        }







    }
}