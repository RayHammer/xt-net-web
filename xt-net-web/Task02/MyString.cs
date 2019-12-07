using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class MyString
    {
        public static readonly int MIN_CAPACITY = 16;

        public static MyString operator +(MyString str1, MyString str2)
        {
            MyString res = new MyString(str1);
            res.Length = str1.Length + str2.Length;
            for (var i = 0; i < str2.Length; i++)
            {
                res[str1.Length + i] = str2[i];
            }
            return res;
        }

        public static MyString operator +(MyString str1, char c)
        {
            MyString res = new MyString(str1);
            res.Length = str1.Length + 1;
            res[str1.Length] = c;
            return res;
        }

        public static bool operator ==(MyString str1, MyString str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }
            for (var i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyString str1, MyString str2)
        {
            return !(str1 == str2);
        }

        public char this[int i]
        {
            get
            {
                if (i < 0 || i >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return str[i];
            }
            set
            {
                if (i < 0 || i >= Length)
                {
                    throw new IndexOutOfRangeException();
                }
                str[i] = value;
            }
        }

        public static implicit operator MyString(string s)
        {
            return new MyString(s);
        }

        public static explicit operator string(MyString mystring)
        {
            return mystring.ToString();
        }

        public static implicit operator MyString(char[] s)
        {
            var res = new MyString(s.Length);
            for (var i = 0; i < res.Length; i++)
            {
                res[i] = s[i];
            }
            return res;
        }

        public static explicit operator char[](MyString mystring)
        {
            var res = new char[mystring.Length];
            for (var i = 0; i < res.Length; i++)
            {
                res[i] = mystring[i];
            }
            return res;
        }

        public MyString()
            : this(capacity: MIN_CAPACITY)
        {
        }

        public MyString(int capacity)
        {
            Capacity = capacity;
            Length = 0;
        }

        public MyString(MyString mystring)
        {
            Capacity = mystring.Capacity;
            Length = mystring.Length;
            for (var i = 0; i < Length; i++)
            {
                this[i] = mystring[i];
            }
        }

        public MyString(string s)
        {
            Capacity = Length = s.Length;
            for (var i = 0; i < Length; i++)
            {
                this[i] = s[i];
            }
        }

        public int Length
        {
            get => length;
            private set
            {
                length = value;
                int newCapacity = Capacity;
                if (newCapacity < MIN_CAPACITY)
                {
                    newCapacity = MIN_CAPACITY;
                }
                    while (newCapacity < length)
                {
                    newCapacity *= 2;
                }
                while (newCapacity / 2 > length && newCapacity / 2 > MIN_CAPACITY)
                {
                    newCapacity /= 2;
                }
                Capacity = newCapacity;
            }
        }

        private int Capacity
        {
            get
            {
                if (str == null)
                {
                    str = new char[MIN_CAPACITY];
                }
                return str.Length;
            }
            set
            {
                char[] str1 = new char[value];
                for (var i = 0; i < Length; i++)
                {
                    str1[i] = this[i];
                }
                str = str1;
            }
        }

        public override string ToString()
        {
            return new string(str);
        }

        private char[] str;
        private int length;
    }
}
