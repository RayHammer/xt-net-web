using System;
using System.Collections.Generic;
using System.Text;

namespace Task00
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Task();
            t.Array();
        }
    }

    class Task
    {
        public void Sequence(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var sb = new StringBuilder();
            for (var i = 1; i <= n; i++)
            {
                if (i > 1)
                {
                    sb.Append(", ");
                }
                sb.Append(i);
            }
            Console.WriteLine(sb.ToString());
        }

        public bool Prime(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (n == 1)
            {
                return false;
            }
            int r = (int)Math.Sqrt(n);
            for (int i = 2; i <= r; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void Square(int n)
        {
            if (n <= 0 || n % 2 == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var res = new StringBuilder();
            var buff = new StringBuilder();
            buff.Append('*', n).Append("\n");
            string line = buff.ToString();
            buff[n / 2] = ' ';
            string lineCentral = buff.ToString();
            for (var i = 0; i < n; i++)
            {
                if (i == n / 2)
                {
                    res.Append(lineCentral);
                }
                else
                {
                    res.Append(line);
                }
            }
            Console.WriteLine(res.ToString());
            return;
        }

        public void Array()
        {
            var rand = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            var a = new int[n][];
            for (var i = 0; i < n; i++)
            {
                var m = Convert.ToInt32(Console.ReadLine());
                a[i] = new int[m];
                for (var j = 0; j < m; j++)
                {
                    a[i][j] = rand.Next(0, 101);
                }
            }
            DisplayArray(a);
            Console.WriteLine();
            for (var i = 0; i < a.Length; i++)
            {
                System.Array.Sort(a[i]);
            }
            DisplayArray(a);
        }

        public void DisplayArray(int[][] a)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            for (var i = 0; i < a.Length; i++)
            {
                sb.Append("{");
                for (var j = 0; j < a[i].Length; j++)
                {
                    sb.Append(a[i][j] + ",");
                }
                sb.Append("},");
            }
            sb.Append("},");
            Console.WriteLine(sb.ToString());
        }
    }
}
