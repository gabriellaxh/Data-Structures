using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class QueueNode<T>
    {
        private T value;
        public QueueNode<T> Next { get; set; }
        public QueueNode<T> Previous { get; set; }

        public QueueNode(T value, QueueNode<T> next = null, QueueNode<T> previous = null)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }

        public T Value
        {
            get => this.value;
            private set => this.value = value;
        }
    }
}
