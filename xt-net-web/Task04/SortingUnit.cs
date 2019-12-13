using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task04
{
    class SortingUnit
    {
        public event EventHandler<object> Finished;
        public object Array
        {
            get; set;
        }

        public static void CustomSort<T>(T[] array, Func<T, T, int> comparer)
        {
            LameSort(array, comparer);
        }
        public void CustomSortThreaded<T>(T[] array, Func<T, T, int> comparer)
        {
            var t = new Thread(() =>
            {
                Array = array;
                LameSort(array, comparer);
                Finished?.Invoke(this, array);
            });
            t.Start();
        }

        protected static void LameSort<T>(KeyValuePair<T[], Func<T, T, int>> pair)
        {
            LameSort(pair.Key, pair.Value);
        }
        protected static void LameSort<T>(T[] arr, Func<T, T, int> comparer)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (comparer(arr[i], arr[j]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
