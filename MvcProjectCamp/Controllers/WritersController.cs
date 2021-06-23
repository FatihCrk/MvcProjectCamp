using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;


namespace MvcProjectCamp.Controllers
{
    public class WritersController : Controller
    {



        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer


        public ActionResult WritersList()
        {
            var writerValues = wm.GetWriterList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {


            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAddBl(p);
                return RedirectToAction("WritersList");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByWriterId(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {

           
                ValidationResult results = writerValidator.Validate(p);
                if (results.IsValid)
                {
                    wm.WriterUpdate(p);
                    return RedirectToAction("WritersList");

                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                    }

                    return View();
                }
           

        }

       

    }
}