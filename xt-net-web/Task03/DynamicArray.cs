using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03
{
    class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        public DynamicArray()
            : this(8)
        {
        }
        public DynamicArray(int capacity)
        {
            Length = 0;
            ChangeCapacity(capacity);
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            Length = 0;
            ChangeCapacity(0);
            AddRange(collection);
        }

        public T this[int index]
        {
            get
            {
                return data[AsIndex(index)];
            }
            set
            {
                data[AsIndex(index)] = value;
            }
        }
        public void Add(T item)
        {
            if (Length == Capacity)
            {
                if (Capacity == 0)
                {
                    ChangeCapacity(1);
                }
                else
                {
                    ChangeCapacity(Capacity * 2);
                }
            }
            data[Length++] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            var collectionLength = 0;
            foreach (var i in collection)
            {
                collectionLength++;
            }
            if (Length + collectionLength > Capacity)
            {
                ChangeCapacity(Length + collectionLength);
            }
            foreach (var i in collection)
            {
                data[Length++] = i;
            }
        }
        public int Capacity
        {
            get => data.Length;
        }
        public void ChangeCapacity(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (capacity < Length)
            {
                Length = capacity;
            }
            if (Length == 0 || this.data == null)
            {
                this.data = new T[capacity];
            }
            T[] data = new T[capacity];
            for (var i = 0; i < Length; i++)
            {
                data[i] = this.data[i];
            }
            this.data = data;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        public DynamicArray<T> Clone()
        {
            var res = new DynamicArray<T>(Capacity);
            foreach (var i in this)
            {
                res.Add(i);
            }
            return res;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(data, Length);
        }
        public bool Insert(int index, T value)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length == Capacity)
            {
                if (Capacity == 0)
                {
                    ChangeCapacity(1);
                }
                else
                {
                    ChangeCapacity(Capacity * 2);
                }
            }
            Length++;
            for (var i = Length - 1; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = value;
            return true;
        }
        public int Length
        {
            get; protected set;
        }
        public bool Remove(T item)
        {
            int index = 0;
            while (index < Length)
            {
                if (data[index].Equals(item))
                {
                    for (var i = index; i < Length - 1; i++)
                    {
                        data[i] = data[i + 1];
                    }
                    Length--;
                    return true;
                }
                index++;
            }
            return false;
        }
        public T[] ToArray()
        {
            T[] res = new T[Length];
            for (var i = 0; i < Length; i++)
            {
                res[i] = data[i];
            }
            return res;
        }

        protected T[] data;
        protected int AsIndex(int index)
        {
            if (index >= Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index < 0)
            {
                return Length + index;
            }
            else
            {
                return index;
            }
        }

        public struct Enumerator : IEnumerator<T>
        {
            public Enumerator(T[] data, int length)
            {
                this.data = data;
                this.length = length;
                position = -1;
            }

            object IEnumerator.Current
            {
                get => Current;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return data[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose()
            {
                data = null;
            }

            public bool MoveNext()
            {
                return ++position < length;
            }

            public void Reset()
            {
                position = -1;
            }

            private T[] data;
            private int position;
            private int length;
        }
    }

    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray()
            : this(8)
        {
        }
        public CycledDynamicArray(int capacity)
            : base(capacity)
        {
        }
        public CycledDynamicArray(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public new Enumerator GetEnumerator()
        {
            return new Enumerator(data, Length);
        }

        public new struct Enumerator : IEnumerator<T>
        {
            public Enumerator(T[] data, int length)
            {
                this.data = data;
                this.length = length;
                position = -1;
            }

            object IEnumerator.Current
            {
                get => Current;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return data[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose()
            {
                data = null;
            }

            public bool MoveNext()
            {
                position = ++position % length;
                return true;
            }

            public void Reset()
            {
                position = -1;
            }

            private T[] data;
            private int position;
            private int length;
        }
    }
}
