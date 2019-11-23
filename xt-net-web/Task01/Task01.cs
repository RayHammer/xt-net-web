using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Task01
    {
        public void Solve(int n)
        {
            string[] names =
                { "Rectangle", "Triangle", "Another Triangle",
                "X-mas Tree", "Sum of Numbers", "Font Adjustment",
                "Array Processing", "No Positive", "Non-Negative Sum", 
                "2D Array", "Average String Length", "Char Doubler" };
            Console.WriteLine("TASK 01.{0}: {1}\n", n, names[n - 1]);
            switch (n)
            {
            case 1:
                Rectangle();
                break;
            case 2:
                Triangle();
                break;
            case 3:
                AnotherTriangle();
                break;
            case 4:
                XmasTree();
                break;
            case 5:
                SumOfNumbers();
                break;
            case 6:
                FontAdjustment();
                break;
            case 7:
                ArrayProcessing();
                break;
            case 8:
                NoPositive();
                break;
            case 9:
                NonNegativeSum();
                break;
            case 10:
                TwoDArray();
                break;
            case 11:
                AvgStringLength();
                break;
            case 12:
                CharDoubler();
                break;
            default:
                break;
            }
            Console.WriteLine("--- Press any key to continue ---");
            Console.ReadKey();
        }

        /// <summary>
        /// Task 1.1
        /// </summary>
        private void Rectangle()
        {
            try
            {
                int a, b;
                a = ReadVar("a");
                b = ReadVar("b");
                if (a <= 0 || b <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("surface = {0}", a * b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERR] {0}", ex.Message);
                return;
            }
        }

        /// <summary>
        /// Task 1.2
        /// </summary>
        private void Triangle()
        {
            int n = ReadVar("n");
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb.Append('*', i + 1).AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Task 1.3
        /// </summary>
        private void AnotherTriangle()
        {
            int n = ReadVar("n");
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb.Append(' ', n - i - 1);
                sb.Append('*', 2 * i + 1);
                sb.Append(' ', n - i - 1);
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Task 1.4
        /// </summary>
        private void XmasTree()
        {
            int n = ReadVar("n");
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb1.Append(' ', n - i - 1);
                sb1.Append('*', 2 * i + 1);
                sb1.Append(' ', n - i - 1);
                sb1.AppendLine();
                sb.Append(sb1);
            }
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Task 1.5
        /// </summary>
        private void SumOfNumbers()
        {
            int i = 0, sum = 0;
            while (true)
            {
                i += 3;
                if (i >= 1000)
                {
                    break;
                }
                if (i % 5 != 0)
                {
                    sum += i;
                }
            }
            i = 0;
            while (true)
            {
                i += 5;
                if (i >= 1000)
                {
                    break;
                }
                sum += i;
            }
            Console.WriteLine("sum = {0}", sum);
        }

        /// <summary>
        /// Task 1.6
        /// </summary>
        private void FontAdjustment()
        {
            var fs = FontStyle.None;
            Console.WriteLine("Please input:");
            for (var i = 1; i <= 3; i++)
            {
                Console.WriteLine("\t{0}: {1}", i, (FontStyle)(1 << (i - 1)));
            }
            Console.WriteLine("Input 0 to quit");
            Console.WriteLine("---");
            while (true)
            {
                Console.WriteLine("Current Font Style: {0}", fs);
                var val = int.Parse(Console.ReadLine());
                if (val < 0 || val > 3)
                    throw new ArgumentOutOfRangeException();
                if (val == 0)
                    break;
                fs = (FontStyle)((int)fs ^ (1 << (val - 1)));
            }
        }

        /// <summary>
        /// Task 1.7
        /// </summary>
        private void ArrayProcessing()
        {
            int[] arr = new int[10];
            var rnd = new Random();
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-99, 100);
            }
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine("min = {0}", arr[0]);
            Console.WriteLine("max = {0}", arr[arr.Length - 1]);
            Console.Write('{');
            foreach (var i in arr)
            {
                Console.Write("{0},", i);
            }
            Console.WriteLine("},");
        }

        /// <summary>
        /// Task 1.8
        /// </summary>
        private void NoPositive()
        {
            int[,,] arr = new int[2, 2, 2];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    for (var k = 0; k < arr.GetLength(2); k++)
                    {
                        Console.Write("arr[{0}, {1}, {2}] = ", i, j, k);
                        arr[i, j, k] = int.Parse(Console.ReadLine());
                    }
                }
            }
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    for (var k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
            var sb = new StringBuilder();
            sb.Append('{');
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                sb.Append('{');
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sb.Append('{');
                    for (var k = 0; k < arr.GetLength(2); k++)
                    {
                        sb.Append(arr[i, j, k]).Append(',');
                    }
                    sb.Append("},");
                }
                sb.Append("},");
            }
            sb.Append("},");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Task 1.9
        /// </summary>
        private void NonNegativeSum()
        {
            int[] arr = new int[10];
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[{0}] = ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            var sum = 0;
            foreach (var i in arr)
            {
                sum += (i > 0) ? i : 0;
            }
            Console.WriteLine("sum = {0}", sum);
        }

        /// <summary>
        /// Task 1.10
        /// </summary>
        private void TwoDArray()
        {
            var arr = new int[3, 3];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("arr[{0}, {1}] = ", i, j);
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }
            var sum = 0;
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    sum += ((i + j) % 2 == 0) ? arr[i, j] : 0;
                }
            }
            Console.WriteLine("sum = {0}", sum);
        }

        /// <summary>
        /// Task 1.11
        /// </summary>
        private void AvgStringLength()
        {
            Console.Write("str = ");
            string str = Console.ReadLine();
            int charCount = 0, wordCount = 0;
            bool isWord = false;
            for (var i = 0; i < str.Length; i++)
            {
                if (Char.IsLetterOrDigit(str, i))
                {
                    isWord = true;
                    charCount++;
                }
                else
                {
                    if (isWord)
                    {
                        wordCount++;
                        isWord = false;
                    }
                }
            }
            if (isWord)
                wordCount++;

            Console.WriteLine("res = {0}", (float)charCount / wordCount);
        }

        /// <summary>
        /// Task 1.12
        /// </summary>
        private void CharDoubler()
        {
            string str1, str2;
            Console.Write("str1 = ");
            str1 = Console.ReadLine();
            Console.Write("str2 = ");
            str2 = Console.ReadLine();

            var sb = new StringBuilder();
            for (var i = 0; i < str1.Length; i++)
            {
                char c = str1[i];
                sb.Append(c);
                if (str2.Contains(c))
                {
                    sb.Append(c);
                }
            }
            Console.WriteLine(sb.ToString());
        }

        private int ReadVar(string var)
        {
            Console.Write(var + " = ");
            return int.Parse(Console.ReadLine());
        }

        private void QuickSort(int[] arr, int l, int r)
        {
            if (l >= r)
                return;
            int p = QSPartition(arr, l, r);
            if (p > 1)
            {
                QuickSort(arr, l, p - 1);
            }
            if (p + 1 < r)
            {
                QuickSort(arr, p + 1, r);
            }
        }

        private int QSPartition(int[] arr, int l, int r)
        {
            int pivot = arr[l];
            while (true)
            {
                while (arr[l] < pivot)
                    l++;
                while (arr[r] > pivot)
                    r--;
                if (l < r)
                {
                    if (arr[l] == arr[r])
                        return r;
                    int temp = arr[l];
                    arr[l] = arr[r];
                    arr[r] = temp;
                }
                else
                {
                    return r;
                }
            }
        }

        [Flags]
        private enum FontStyle
        {
            None = 0x0,
            Bold = 0x1,
            Italic = 0x2,
            Underlined = 0x4
        }
    }
}
