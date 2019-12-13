using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Seeker
    {
        public static List<int> GetPositive(IEnumerable<int> collection)
        {
            var list = new List<int>();
            foreach (var i in collection)
            {
                if (i > 0)
                    list.Add(i);
            }
            return list;
        }

        public static List<int> GetCertain(IEnumerable<int> collection, Predicate<int> predicate)
        {
            var list = new List<int>();
            foreach (var i in collection)
            {
                if (predicate(i))
                    list.Add(i);
            }
            return list;
        }
    }
}
