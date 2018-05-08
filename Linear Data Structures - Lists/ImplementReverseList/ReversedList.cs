using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReversedList
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;

        public ReversedList()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public int Capacity => this.items.Length;

        public T this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.items[index];
            }

            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
                this.Resize();

            this.items[this.Count++] = item;
        }

        public void RemoveAt(int index)
        {
            try
            {
                this.items[this.Count - index - 1] = default(T);

                for (int i = this.Count - index - 1; i < this.Count - 1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
                this.Count--;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Resize()
        {
            T[] newArr = new T[this.items.Length * 2];
            Array.Copy(this.items, newArr, this.items.Length);
            this.items = newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }
    }
}
