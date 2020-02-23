using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task10.Models
{
    public static class AuthModel
    {
        public static Dictionary<string, string> AuthList
        {
            get; private set;
        }

        static AuthModel()
        {
            AuthList = new Dictionary<string, string>
            {
                ["admin"] = "admin",
                ["user"] = "password"
            };
        }

        public static bool LoginSuccessful(string username, string password)
        {
            return AuthList[username] == password;
        }

        public static bool RegisterUser(string username, string password)
        {
            if (AuthList.ContainsKey(username))
                return false;
            AuthList[username] = password;
            return true;
        }
    }
}