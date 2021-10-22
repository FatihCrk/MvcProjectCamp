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
    public class RoleManager : IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetRoleList()
        {
            return _roleDal.List();
        }


        public Heading GetByRoleId(int id)
        {
            throw new NotImplementedException();
        }

      
        public void RoleAddBl(Role role)
        {
            throw new NotImplementedException();
        }

        public void RoleDelete(Role role)
        {
            throw new NotImplementedException();
        }

        public void RoleUpdate(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
