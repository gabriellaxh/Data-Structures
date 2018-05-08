using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class StackNode<T>
    {
        private T value;
        public StackNode<T> Next { get; set; }

        public StackNode(T value, StackNode<T> next = null)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value
        {
            get => this.value;
            private set => this.value = value;
        }
    }
}
