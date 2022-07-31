using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication8.Models;

namespace WebApplication8.Security
{
    public class MyRoles : RoleProvider
    {
        public override string ApplicationName {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (welfareDBEntities db = new welfareDBEntities())
            {
                var userRoles = (from u in db.users_table
                                 join r in db.user_role_mapping
                                 on u.user_id equals r.user_id
                                 join ur in db.user_type_table
                                 on r.user_type_id equals ur.user_type_id
                                 where u.user_name == username
                                 select ur.user_type).ToArray();
                return userRoles;
            }
        }




        public override string[] GetUsersInRole(string roleName)
        {

            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}