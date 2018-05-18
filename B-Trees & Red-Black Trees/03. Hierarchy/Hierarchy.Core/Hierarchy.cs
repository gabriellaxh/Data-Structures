namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root;
        private Dictionary<T, Node> hierarchy;

        public Hierarchy(T root)
        {
            this.root = new Node(root);

            this.hierarchy = new Dictionary<T, Node>();
            hierarchy.Add(root, this.root);
        }

        public int Count
        {
            get
            {
                return this.hierarchy.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (!this.hierarchy.ContainsKey(element))
                throw new ArgumentException();

            if (this.hierarchy.ContainsKey(child))
                throw new ArgumentException();

            Node parentNode = this.hierarchy[element];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this.hierarchy.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (!this.hierarchy.ContainsKey(element))
                throw new ArgumentException();

            if (element.Equals(root.Value))
                throw new InvalidOperationException();

            Node node = this.hierarchy[element];
            if (node.Children.Count != 0)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node.Parent;
                    node.Parent.Children.Add(child);
                }
            }

            node.Parent.Children.Remove(node);
            this.hierarchy.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.hierarchy.ContainsKey(item))
                throw new InvalidOperationException();

            Node node = this.hierarchy[item];

            return node.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            if (!this.hierarchy.ContainsKey(item))
                throw new ArgumentException();

            Node node = this.hierarchy[item];

            if (node.Parent == null)
                return default(T);
            
            return node.Parent.Value;
        }

        public bool Contains(T value)
        {
            if (this.hierarchy.ContainsKey(value))
                return true;

            return false;

        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> matchingElements = new List<T>();

            foreach (var element in this.hierarchy.Keys)
            {
                if (other.Contains(element))
                {
                    matchingElements.Add(element);
                }
            }

            return matchingElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Breadth-First Search
            Queue<Node> queue = new Queue<Node>();

            Node current = this.root;

            queue.Enqueue(current);
            while(queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current.Value;

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private class Node
        {
            public Node Parent { get; set; }
            public T Value { get; set; }
            public List<Node> Children { get; set; }

            public Node(T value, Node parent = null)
            {
                this.Parent = parent;
                this.Value = value;
                this.Children = new List<Node>();
            }
        }
    }
}