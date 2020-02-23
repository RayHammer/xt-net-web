using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Task10.Models
{
    public class AppRoleProvider : RoleProvider
    {
        private static readonly Dictionary<string, List<string>> roles = new Dictionary<string, List<string>>();

        public AppRoleProvider()
        {
            roles["admin"] = new List<string>()
            {
                "Admin"
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

        public static bool UserHasRole(string username, string roleName)
        {
            return roles.ContainsKey(username) && roles[username].Contains(roleName);
        }

        public static bool PromoteUser(string username)
        {
            if (roles.ContainsKey(username))
                return false;
            roles[username] = new List<string>() { "Admin" };
            return true;
        }

        public static bool DemoteUser(string username)
        {
            if (!roles.ContainsKey(username))
                return false;
            roles[username].Remove("Admin");
            if (roles[username].Count == 0)
            {
                roles.Remove(username);
            }
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