using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class LinkedStack<T>
    {
        private StackNode<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new StackNode<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();

            var currentNode = this.firstNode.Value;
            this.firstNode = this.firstNode.Next;
            this.Count--;
            return currentNode;

        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            int index = 0;
            var currentNode = this.firstNode;

            while(currentNode != null)
            {
                newArray[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return newArray;
        }

    }
}
