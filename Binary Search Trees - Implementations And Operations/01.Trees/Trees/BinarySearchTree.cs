using System;
using System.Collections.Generic;
using Trees;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public BinarySearchTree(Node<T> root = null)
    {
        this.root = root;
    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node<T>(value);
            return;
        }

        Node<T> parent = null;
        Node<T> current = this.root;

        while (current != null)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                parent = current;
                current = current.Left;
            }

            else if (value.CompareTo(current.Value) > 0)
            {
                parent = current;
                current = current.Right;
            }
        }

        Node<T> newNode = new Node<T>(value);

        if (value.CompareTo(parent.Value) < 0)
            parent.Left = newNode;

        else
            parent.Right = newNode;
    }

    public bool Contains(T value)
    {
        Node<T> currentNode = this.root;
        while (currentNode != null)
        {
            if (value.CompareTo(currentNode.Value) < 0)
                currentNode = currentNode.Left;

            else if (value.CompareTo(currentNode.Value) > 0)
                currentNode = currentNode.Right;

            else
                break;
        }
        return currentNode != null;
    }

    public void DeleteMin()
    {
        if (this.root == null)
            return;

        Node<T> parent = null;
        Node<T> min = this.root;
        while(min.Left != null)
        {
            parent = min;
            min = parent.Left;
        }

        if (parent == null)
            this.root = min.Right;

        else
            parent.Left = min.Right;
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node<T> currentNode = this.root;
        while (currentNode != null)
        {
            if (item.CompareTo(currentNode.Value) < 0)
                currentNode = currentNode.Left;

            else if (item.CompareTo(currentNode.Value) > 0)
                currentNode = currentNode.Right;

            else
                break;
        }

        if (currentNode == null)
            return null;

        return new BinarySearchTree<T>(currentNode);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node<T> node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
            return;

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
            this.Range(node.Left, queue, startRange, endRange);

        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
            queue.Enqueue(node.Value);

        if (nodeInHigherRange > 0)
            this.Range(node.Right, queue, startRange, endRange);
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.root != null)
            this.EachInOrder(action, this.root);
    }

    private void EachInOrder(Action<T> action, Node<T> root)
    {
        if (root.Left != null)
            this.EachInOrder(action, root.Left);

        action(root.Value);

        if (root.Right != null)
            this.EachInOrder(action, root.Right);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {

    }
}
