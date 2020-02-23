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
        } = new Dictionary<string, string>();

        public static bool LoginSuccessful(string username, string password)
        {
            return password == "admin";
        }
    }
}