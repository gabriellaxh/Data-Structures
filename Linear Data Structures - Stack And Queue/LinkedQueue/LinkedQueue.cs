using LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        public int Count { get; private set; }
        private QueueNode<T> Head { get; set; }
        private QueueNode<T> Tail { get; set; }


        public void Enqueue(T element)
        {
            if (this.Count == 0)
                this.Head = this.Tail = new QueueNode<T>(element);
            
            else
            {
                var newEl = new QueueNode<T>(element);
                newEl.Previous = this.Tail;
                this.Tail.Next = newEl;
                this.Tail = newEl;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            var head = this.Head.Value;
            this.Head = this.Head.Next;

            if (this.Head != null)
                this.Head.Previous = null;
            else
                this.Tail = null;

            this.Count--;
            return head;
        }

        public T[] ToArray()
        {
            T[] newArr = new T[this.Count];
            int index = 0;
            var currentNode = this.Head;
            while(currentNode != null)
            {
                newArr[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return newArr;
        }
    }
}
