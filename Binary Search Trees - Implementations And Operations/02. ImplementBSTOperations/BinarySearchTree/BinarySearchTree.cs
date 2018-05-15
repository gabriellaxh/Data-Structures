using System;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;


    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
                current = current.Left;

            else if (current.Value.CompareTo(element) < 0)
                current = current.Right;

            else
                break;
        }

        return current;
    }


    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }


    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);
        return node;
    }


    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value); //
        int nodeInHigherRange = endRange.CompareTo(node.Value); //

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }


    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }


    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }
    

    public void DeleteMin()
    {
        this.root = this.DeleteMin(this.root);

        #region Another Way
        //Node current = this.root;
        //Node parent = null;
        //while (current.Left != null)
        //{
        //    parent = current;
        //    current = current.Left;
        //}

        //if (parent == null)
        //{
        //    this.root = this.root.Right;
        //}
        //else
        //{
        //    parent.Left = current.Right;
        //}
        #endregion
    }

    private Node DeleteMin(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.Left == null)
        {
            return node.Right;
        }


        node.Left = this.DeleteMin(node.Left);
        node.Count--;

        return node;
    }


    public void DeleteMax()
    {
        this.root = DeleteMax(this.root);

        #region Another Way
        //if (root == null)
        //{
        //    return;
        //}

        //Node current = root;
        //Node parent = null;
        //while (current.Right != null)
        //{
        //    parent = current;
        //    current = current.Right;
        //}

        //if (parent == null)
        //{
        //    this.root = this.root.Left;
        //}

        //else
        //{
        //    parent.Right = current.Left;
        //}
        #endregion
    }
    
    private Node DeleteMax(Node node)
    {
        if(node == null)
        {
            return null;
        }

        if(node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);
        node.Count--;

        return node;
    }


    public void Delete(T element)
    {
        this.root = Delete(element, this.root);
    }

    private Node Delete(T element, Node node)
    {
        if (node == null)
            return node;

        int compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            node.Left = this.Delete(element, node.Left);
        }

        else if (compare > 0)
        {
            node.Right = this.Delete(element, node.Right);
        }

        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if(node.Right == null)
            {
                return node.Left;
            }

            node.Value = minRec(node.Right);
            node.Right = Delete(node.Value, node.Right);
        }

        return node;
    }

    private T minRec(Node node)
    {
        T minVal = node.Value;

        while(node.Left != null)
        {
            minVal = node.Left.Value;
            node = node.Left;
        }

        return minVal;
    }

    
    public int Count()
    {
        return this.Count(this.root);
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }


    public int Rank(T element)
    {
        var rank = Rank(element, this.root);
        return rank;
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
            return 0;

        if (element.CompareTo(node.Value) < 0)
            return this.Rank(element, node.Left);


        else if (element.CompareTo(node.Value) > 0)
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);


        return this.Count(node.Left);
    }


    public T Select(int rank)
    {
        if (this.root == null)
            throw new ArgumentNullException();

        if (this.root.Count <= rank)
            throw new InvalidOperationException();

        Node current = this.Select(root, rank);

        return current.Value;

    }

    private Node Select(Node node, int rank)
    {
        if (node.Left != null)
        {
            if (node.Left.Count > rank)
                return this.Select(node.Left, rank);

            else if (node.Left.Count < rank)
                return this.Select(node.Right, rank - (1 + node.Left.Count));

            else
                return node;
        }
        return node;
    }


    public T Ceiling(T element)
    {
        return this.Select(this.Rank(element));
    }

    public T Floor(T element)
    {
        return this.Select(this.Rank(element) - 1);

        //if (this.root == null)
        //    throw new InvalidOperationException();

        //Node floor = Floor(element, this.root);

        //if (floor == null)
        //    throw new InvalidOperationException();

        //return floor.Value;
    }

    //private Node Floor(T element, Node node)
    //{
    //    //if (node == null)
    //    //    return node;


    //    //int root2element = node.Value.CompareTo(element);

    //    //if (root2element >= 0)
    //    //    return this.Floor(element, node.Left);

    //    //else
    //    //{
    //    //    if (node.Right != null)
    //    //    {
    //    //        var res = this.Floor(element, node.Right);
    //    //        if (res == null)
    //    //        {
    //    //            return node;
    //    //        }
    //    //        return res;
    //    //    }
    //    //    return node;
    //    //}
    //}

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public int Count { get; set; }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(8);
        bst.Insert(3);
        bst.Insert(10);
        bst.Insert(1);
        bst.Insert(6);
        bst.Insert(14);
        bst.Insert(4);
        bst.Insert(7);
        bst.Insert(13);

    }
}