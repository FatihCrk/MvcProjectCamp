using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MyAboutManager : IMyAboutService
    {
        IMyAboutDal _myAboutDal;

        public MyAboutManager(IMyAboutDal myAboutDal)
        {
            _myAboutDal = myAboutDal;
        }

        public MyAbout GetByMyAboutId(int id)
        {
            return _myAboutDal.GetById(x => x.SkillId == id);
        }

        public List<MyAbout> GetMyAboutList()
        {
            return _myAboutDal.List();
        }

        public void MyAboutAddBl(MyAbout myAbout)
        {
           _myAboutDal.Insert(myAbout);
        }

        public void MyAboutDelete(MyAbout myAbout)
        {
            _myAboutDal.Delete(myAbout);
        }

        public void MyAboutUpdate(MyAbout myAbout)
        {
           _myAboutDal.Update(myAbout);
        }
    }
}
