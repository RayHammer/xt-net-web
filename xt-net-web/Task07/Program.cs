using System;
using System.Collections.Generic;

namespace Task07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var task = new Task07();

            Action<string> action = task.TimeCounter;
            string[] tests =
            {
                "0:00", "The time is 7:40",
                "23:59", "16:77",
                "Between 7:00 and 19:30",
                "3:50-4:20", "7:411",
                "023:47"
            };
            RunWithTests(action, tests);

            Console.ReadKey();
        }

        public static void RunWithTests(Action<string> action, IEnumerable<string> tests)
        {
            foreach (var test in tests)
            {
                Console.WriteLine($"Testing: {test}");
                action.Invoke(test);
                Console.WriteLine();
            }
        }

        public static void PassToUser(Action<string> action)
        {
            Console.WriteLine("Please input text.");
            action.Invoke(Console.ReadLine());
        }
    }
}