using System;
using System.Collections.Generic;

namespace Task03
{
    class Task03
    {
        public static void Lost()
        {
            int n = 0;
            try
            {
                Console.Write("n = ");
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Couldn't parse n. Using n = 5.");
                n = 5;
            }
            var circle = new int[n];
            for (var i = 0; i < n; i++)
            {
                circle[i] = i;
            }
            int left = n;
            int it = 0;
            int c = 0;
            while (left > 0)
            {
                if (circle[it] < 0)
                {
                    it = ++it % n;
                    continue;
                }
                c = ++c % 2;
                if (c == 0)
                {
                    if (left == 1)
                    {
                        Console.WriteLine("Person #" + circle[it] + " is the only one left.");
                        break;
                    }
                    Console.WriteLine("Person #" + circle[it] + " is out.");
                    circle[it] = -1;
                    left--;
                }
                it = ++it % n;
            }
        }

        public static void WordFrequency()
        {
            Console.WriteLine("Please input text.");
            string[] input = Console.ReadLine().ToLower().Split(' ', '.');
            var dict = new Dictionary<string, int>();
            foreach (var i in input)
            {
                if (i.Length == 0)
                {
                    continue;
                }
                if (!dict.ContainsKey(i))
                {
                    dict[i] = 1;
                }
                else
                {
                    dict[i]++;
                }
            }
            foreach (var i in dict)
            {
                Console.WriteLine(i.Key + ": " + i.Value);
            }
        }

        public static void DynamicArrayPreview()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5 };
            var arrCycle = new CycledDynamicArray<int>(arr1);
            var count = 0;
            foreach (var i in arrCycle)
            {
                Console.WriteLine(i);
                count++;
                if (count >= 10)
                {
                    break;
                }
            }
        }
    }
}
