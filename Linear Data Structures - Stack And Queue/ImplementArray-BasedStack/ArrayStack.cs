using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementArray_BasedStack
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[InitialCapacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
                this.Grow();

            this.elements[this.Count] = element;
            this.Count++;

        }

        public T Pop()
        {
            if (this.elements.Length == 0)
                throw new InvalidOperationException();
                
            this.Count--;
            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            T[] newElements = new T[this.elements.Length];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
            return this.elements;
        }

        private void Grow()
        {
            T[] newElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newElements, this.elements.Length);
            this.elements = newElements;
        }
    }
}
