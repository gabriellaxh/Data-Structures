using System;
using System.Collections.Generic;

public class IntervalTree
{
    private class Node
    {
        internal Interval Interval;
        internal double Max;
        internal Node Right;
        internal Node Left;

        public Node(Interval interval)
        {
            this.Interval = interval;
            this.Max = interval.Hi;
        }
    }

    private Node root;

    public void Insert(double lo, double hi)
    {
        this.root = this.Insert(this.root, lo, hi);
    }

    public void EachInOrder(Action<Interval> action)
    {
        EachInOrder(this.root, action);
    }

    public Interval SearchAny(double lo, double hi)
    {
        Node node = this.root;
        while (node != null && !node.Interval.Intersects(lo, hi))
        {
            if (node.Left != null && node.Left.Max > lo)
                node = node.Left;
            else
                node = node.Right;
        }

        if (node != null)
            return node.Interval;

        return null;
    }

    public IEnumerable<Interval> SearchAll(double lo, double hi)
    {
        var result = new List<Interval>();
        this.SearchAll(this.root, lo, hi, result);
        return result;
    }

    private void SearchAll(Node node, double lo, double hi, List<Interval> result)
    {
        if (node == null)
            return;

        bool goingLeftPossible = node.Left != null && node.Left.Max > lo;
        bool goingRightPossible = node.Right != null && node.Right.Interval.Lo < hi;

        if (goingLeftPossible)
            this.SearchAll(node.Left, lo, hi, result);

        if (node.Interval.Intersects(lo, hi))
            result.Add(node.Interval);

        if (goingRightPossible)
            this.SearchAll(node.Right, lo, hi, result);
    }

    private void UpdateMaxEndpoint(Node node)
    {
        var maxChild = GetMax(node.Left, node.Right);
        node.Max = GetMax(node, maxChild).Max;
    }

    private Node GetMax(Node left, Node right)
    {
        if (left == null)
            return right;

        else if (right == null)
            return left;

        else
            return left.Max > right.Max ? left : right;
    }

    private void EachInOrder(Node node, Action<Interval> action)
    {
        if (node == null)
        {
            return;
        }

        EachInOrder(node.Left, action);
        action(node.Interval);
        EachInOrder(node.Right, action);
    }

    private Node Insert(Node node, double lo, double hi)
    {
        if (node == null)
        {
            return new Node(new Interval(lo, hi));
        }

        int cmp = lo.CompareTo(node.Interval.Lo);
        if (cmp < 0)
        {
            node.Left = Insert(node.Left, lo, hi);
        }
        else if (cmp > 0)
        {
            node.Right = Insert(node.Right, lo, hi);
        }

        return node;
    }
}
