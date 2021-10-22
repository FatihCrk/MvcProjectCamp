using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IMyAboutService
    {
        List<MyAbout> GetMyAboutList();
        void MyAboutAddBl(MyAbout myAbout);

        MyAbout GetByMyAboutId(int id);

        void MyAboutDelete(MyAbout myAbout);

        void MyAboutUpdate(MyAbout myAbout);
    }
}
