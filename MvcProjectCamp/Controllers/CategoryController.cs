using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetCategoryList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAddBl(p);
                return RedirectToAction("GetCategoryList");

            }

            else
            {
                foreach (var result in results.Errors)
                {
                    ModelState.AddModelError(result.PropertyName, result.ErrorMessage);
                }

            }
             
            return View();
            
        }

    }
}