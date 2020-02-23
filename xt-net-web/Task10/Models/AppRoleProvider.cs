using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Task10.Models
{
    public class AppRoleProvider : RoleProvider
    {
        private readonly Dictionary<string, List<string>> roles = new Dictionary<string, List<string>>();

        public AppRoleProvider()
        {
            roles["admin"] = new List<string>()
            {
                "User", "Admin"
            };
            roles["user"] = new List<string>()
            {
                "User"
            };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return roles.ContainsKey(username) && roles[username].Contains(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            return roles.ContainsKey(username) ? roles[username].ToArray() : Array.Empty<string>();
        }

        public bool ContainsUser(string username)
        {
            return roles.ContainsKey(username);
        }

        public bool RegisterUser(string username)
        {
            if (ContainsUser(username))
                return false;
            roles[username] = new List<string>() { "User" };
            return true;
        }

        #region NOT_IMPLEMENTED
        public override string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
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

        public override string[] GetUsersInRole(string roleName)
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
        #endregion
    }
}