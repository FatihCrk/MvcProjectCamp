using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();


        //[ActionName("StatisticsPage")]
        public ActionResult StatisticsPage1()
        {
            //StatisticViewModel s = new StatisticViewModel();

            //s.CategoryCount = context.Categories.Count();

            var categoryCount = context.Categories.Count();
            ViewBag.categoryCount = categoryCount;

            var HeadingsinTitleTableSoftwareInfo = context.Headings.Count(x => x.HeadingName == "Yazılım");
            ViewBag.HeadingsinTitleTableSoftwareInfo = HeadingsinTitleTableSoftwareInfo;


            var headingsInTitleWriterInfoCharA = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.HeadingsInTitleWriterInfoCharA = headingsInTitleWriterInfoCharA;


            var moreTitles = context.Categories.Where(c => c.CategoryId == context.Headings.GroupBy(h => h.CategoryId).OrderByDescending(h => h.Count())
                .Select(h => h.Key).FirstOrDefault()).Select(c => c.CategoryName).FirstOrDefault();

            ViewBag.moreTitles = moreTitles;



            var categoryStatusTrue = context.Categories.Where(c => c.CategoryStatus == true).Count();
            var cateoryStatusFalse = context.Categories.Where(c => c.CategoryStatus == false).Count();

            var categoryStatusState = categoryStatusTrue - cateoryStatusFalse;
            ViewBag.categoryStatus = categoryStatusState;


            return View();


        }

        //public class StatisticViewModel()
        //{
        //    public int CategoryCount { get; set; }

        //}
    }
}