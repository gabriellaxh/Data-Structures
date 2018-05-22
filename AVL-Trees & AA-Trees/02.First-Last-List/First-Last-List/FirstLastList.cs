using System;
using System.Collections.Generic;
using System.Linq;
//using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> elements;

    public FirstLastList()
    {
        this.elements = new LinkedList<T>();
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public void Add(T element)
    {
       LinkedListNode<T> node = new LinkedListNode<T>(element);
       this.elements.AddFirst(node);
    }

    public void Clear()
    {
        this.elements.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (this.elements.Count < count)
            throw new ArgumentOutOfRangeException();

        List<T> result = new List<T>();
        LinkedListNode<T> currentNode = this.elements.Last;

        int i = 0;
        while (i < count)
        {
            result.Add(currentNode.Value);
            currentNode = currentNode.Previous;
            i++;
        }

        return result;
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.elements.Count < count)
            throw new ArgumentOutOfRangeException();

        List<T> result = new List<T>();
        LinkedListNode<T> current = this.elements.First;
        int i = 0;

        while (i < count)
        {
            result.Add(current.Value);
            current = current.Next;
            i++;
        }

        return result;
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > this.elements.Count)
            throw new ArgumentOutOfRangeException();

        return this.elements.OrderByDescending(x => x).ThenBy(x => x).Take(count);
    }

    public IEnumerable<T> Min(int count)
    {
        if (count > this.elements.Count)
            throw new ArgumentOutOfRangeException();
        
        return elements.OrderBy(x => x).Take(count);
    }

    public int RemoveAll(T element)
    {
        int count = 0;

        foreach (var num in this.elements.ToList())
        {
            var comp = num.CompareTo(element);
            if (comp == 0)
            {
                this.elements.Remove(num);
                count++;
            }
        }
        return count;
    }
}
