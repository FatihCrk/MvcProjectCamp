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
   public class AdminManager : IAdminService
   {
       IAdminDal _adminDal;

       public AdminManager(IAdminDal adminDal)
       {
           _adminDal = adminDal;
       }


        public List<Admin> GetAdminList()
        {
            return _adminDal.List();
        }

        public void AdminAddBl(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
