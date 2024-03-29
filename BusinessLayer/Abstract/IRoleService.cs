﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IRoleService
    {
        List<Role> GetRoleList();
        void RoleAddBl(Role role);

        Heading GetByRoleId(int id);

        void RoleDelete(Role role);

        void RoleUpdate(Role role);
    }
}
