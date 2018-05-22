using System;
using System.Collections.Generic;
using System.Linq;

public class AVL<T> where T : IComparable<T>
{
    private Node<T> root;
    private HashSet<T> nodesValues;

    public AVL()
    {
        this.nodesValues = new HashSet<T>();
    }

    public Node<T> Root
    {
        get
        {
            return this.root;
        }
    }

    public bool Contains(T item)
    {
        var node = this.Search(this.root, item);
        return node != null;

        //return this.nodesValues.Contains(item);
    }

    public void Insert(T item)
    {
        this.root = this.Insert(this.root, item);
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private Node<T> Insert(Node<T> node, T item)
    {
        if (node == null)
        {
            nodesValues.Add(item);
            return new Node<T>(item);
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            node.Left = this.Insert(node.Left, item);
        }
        else if (cmp > 0)
        {
            node.Right = this.Insert(node.Right, item);
        }

        UpdateHeight(node);
        node = Balance(node);
        UpdateHeight(node);
        return node;
    }

    private Node<T> Search(Node<T> node, T item)
    {
        if (node == null)
        {
            return null;
        }

        int cmp = item.CompareTo(node.Value);
        if (cmp < 0)
        {
            return Search(node.Left, item);
        }
        else if (cmp > 0)
        {
            return Search(node.Right, item);
        }

        return node;
    }

    private void EachInOrder(Node<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private static int Height(Node<T> node)
    {
        if (node == null)
            return 0;

        return node.Height;
    }

    private static void UpdateHeight(Node<T> node)
    {
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }

    private static Node<T> RotateLeft(Node<T> node)
    {
        Node<T> temp = node.Right;
        node.Right = temp.Left;
        temp.Left = node;

        UpdateHeight(node);

        return temp;
    }

    private static Node<T> RotateRight(Node<T> node)
    {
        Node<T> temp = node.Left;
        node.Left = temp.Right;
        temp.Right = node;

        UpdateHeight(node);

        return temp;
    }

    private static Node<T> Balance(Node<T> node)
    {
        int balance = Height(node.Left) - Height(node.Right);

        //Right is heavier
        if (balance < -1)
        {
            balance = Height(node.Right.Left) - Height(node.Right.Right);

            if (balance > 0)
                node.Right = RotateRight(node.Right);

            return RotateLeft(node);

        }
        //Left is heavier
        else if (balance > 1)
        {
            balance = Height(node.Left.Left) - Height(node.Left.Right);

            if (balance < 0)
                node.Left = RotateLeft(node.Left);


            return RotateRight(node);

        }

        return node;
    }
}
