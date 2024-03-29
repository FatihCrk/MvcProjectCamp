﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutService

    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }


        public List<About> GetAboutList()
        {
            return _aboutDal.List();
        }

        public void AboutAddBl(About about)
        {
            _aboutDal.Insert(about);
        }

        public About GetByAboutId(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
            //return _aboutDal.GetById(x => x.CategoryId == id);

        }

        public void AboutDelete(About about)
        {
            /*_aboutDal.Delete(about);*/
            _aboutDal.Update(about);

        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
