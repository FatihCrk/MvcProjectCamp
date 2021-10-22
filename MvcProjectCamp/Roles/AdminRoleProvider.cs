using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DataAccessLayer.Concrete;


namespace MvcProjectCamp.Roles
{
    public class AdminRoleProvider:RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Context context = new Context(); //ÖDEV

            /*Sisteme otantike olan kişinin rolünü getirir. */

            var result =  context.Admins.FirstOrDefault(y => y.AdminUserName == username);

            var resultWriter = context.Writers.FirstOrDefault(y => y.WriterName == username);

            if (result != null)
            {
                return new string[] {result.AdminRole};
            }
            else if (resultWriter != null)
            {
                return new string[] { resultWriter.WriterRole };
            }

            return new string[]{};

        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}