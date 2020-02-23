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
            return AuthList.ContainsKey(username) ? AuthList[username] == password : false;
        }

        public static bool RegisterUser(string username, string password)
        {
            if (AuthList.ContainsKey(username))
                return false;
            AuthList.Add(username, password);
            return true;
        }
    }
}