using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DynamicListGeneric
{
    public class DynamicList<T>: IEnumerable
    {
        private T[] list;
        private int current;

        public DynamicList()
        {
            list = new T[0];
            current = -1;
        }

        public DynamicList(int size)
        {
            list = new T[size];
            current = -1;
        }

        public DynamicList(IEnumerable<T> array)
        {
            list = new T[0];
            current = -1;
            foreach(T item in array)
            {
                this.Add(item);
            }
        }

        public int Count
        {
            get
            {
                return current + 1;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > current)
                {
                    throw new IndexOutOfRangeException();
                }
                return list[index];
            }
            set
            {
                if (index < 0 || index > current)
                {
                    throw new IndexOutOfRangeException();
                }
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            if (0 == list.Length)
            {
                Array.Resize<T>(ref list, 1);
            }
            else if (current == list.Length - 1)
            {
                Array.Resize<T>(ref list, list.Length * 2);
            }

            current++;
            list[current] = item;
        }

        public void Remove(T item)
        {
            int itemIndex = Array.IndexOf(list, item);
            if (itemIndex >= 0)
            {
                list = list.Where((value, index) => index != itemIndex).ToArray();
                current--;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > current)
            {
                throw new IndexOutOfRangeException();
            }

            list = list.Where((value, ind) => ind != index).ToArray();
            current--;
        }

        public void Clear()
        {
            current = -1;
            Array.Resize(ref list, 0);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i <= current; i++)
            {
                yield return list[i];
            }
        }
    }
}
