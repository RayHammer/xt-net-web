using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Task04
    {
        public static void CustomSort<T>(T[] array, Func<T, T, int> comparer)
        {
            SortingUnit.CustomSort(array, comparer);
        }
        public static void CustomSortDemo()
        {
            Console.WriteLine("Please input text:");
            string[] array = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            var comparer = new Func<string, string, int>(StringComparer);
            CustomSort(array, comparer);
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
        }
        public static void SortingUnitDemo()
        {
            Console.WriteLine("Please input text:");
            string[] array1 = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            var comparer = new Func<string, string, int>(StringComparer);
            var su1 = new SortingUnit();
            su1.Finished += SortFinished;
            su1.CustomSortThreaded(array1, comparer);
        }
        public static void NumberArraySum()
        {
            var array = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(array.Sum());
        }
        public static void ToIntOrNotToInt()
        {
            var words = new string[]
            {
                "1234",
                "-1234",
                "5.0",
                "three",
                "f0ur",
                "+255",
                "",
                "45 7",
                "0"
            };
            foreach (var i in words)
            {
                Console.WriteLine("{0} => {1}", i, i.IsUInt());
            }
        }
        public static void ISeekYou()
        {
            var n = 100;
            var input = new List<int>();
            for (var i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    input.Add(i);
                }
                else
                {
                    input.Add(-i);
                }
            }
            var list1 = Seeker.GetPositive(input);
            var list2 = Seeker.GetCertain(input, IsPositive);
            Predicate<int> isPositive = delegate (int _n)
            {
                return _n > 0;
            };
            var list3 = Seeker.GetCertain(input, isPositive);
            var list4 = Seeker.GetCertain(input, (int _n) =>
            {
                return _n > 0;
            });
            var query = from i in input
                        where i > 0
                        select i;
            var list5 = query.ToList();
        }

        private static bool IsPositive(int n)
        {
            return n > 0;
        }
        private static void SortFinished(object sender, object e)
        {
            Console.WriteLine("Finished sorting.");
            var arr = (string[]) e;
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
        }
        private static int StringComparer(string a, string b)
        {
            int al = a.Length, bl = b.Length;
            if (al == bl)
                return 0;
            if (al < bl)
                return -1;
            else
                return 1;
        }
        /// <summary>
        /// A generic quick sort solution.
        /// Doesn't work however for some reason.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="comparer"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private static void QuickSort<T>(T[] arr, Func<T, T, int> comparer, int l, int r)
        {
            if (l >= r)
                return;
            int p = QSPartition(arr, comparer, l, r);
            if (p > 1)
            {
                QuickSort(arr, comparer, l, p - 1);
            }
            if (p + 1 < r)
            {
                QuickSort(arr, comparer, p + 1, r);
            }
        }
        private static int QSPartition<T>(T[] arr, Func<T, T, int> comparer, int l, int r)
        {
            T pivot = arr[l];
            while (true)
            {
                while (comparer(arr[l], pivot) == -1)
                    l++;
                while (comparer(arr[r], pivot) == 1)
                    r--;
                if (l < r)
                {
                    if (comparer(arr[l], arr[r]) == 0)
                        return r;
                    T temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                }
                else
                {
                    return r;
                }
            }
        }
    }
}
