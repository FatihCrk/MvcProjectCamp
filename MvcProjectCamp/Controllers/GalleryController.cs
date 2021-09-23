﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MvcProjectCamp.Controllers
{
    [Authorize]
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());

        // GET: Gallery
        public ActionResult Index()
        {
            var getImageList = ifm.GetImageList();
            return View(getImageList);
        }
    }
}