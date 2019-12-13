using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    static class Utility
    {
        public static int Sum(this IEnumerable<int> collection)
        {
            var res = new int();
            foreach (var i in collection)
            {
                res += i;
            }
            return res;
        }

        public static bool IsUInt(this string s)
        {
            if (s.Length == 0)
            {
                return false;
            }
            foreach (var i in s)
            {
                if (!Char.IsDigit(i))
                {
                    return false;
                }
            }
            if (s[0] == 0)
            {
                return false;
            }
            return true;
        }
    }
}
