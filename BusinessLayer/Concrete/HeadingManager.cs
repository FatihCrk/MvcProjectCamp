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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;


        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public void HeadingAddBl(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetByHeadingId(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void HeadingDelete(Heading heading)
        {
           _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }
    }
}
