using Double_Linked_List;
using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
            this.head = this.tail = new ListNode<T>(element);

        else
        {
            var newHead = new ListNode<T>(element);
            newHead.Next = this.head;
            this.head.Previous = newHead;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
            this.head = this.tail = new ListNode<T>(element);

        else
        {
            var newTail = new ListNode<T>(element);
            newTail.Previous = this.tail;
            this.tail.Next = newTail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
            throw new InvalidOperationException("List empty!");

        var firstEl = this.head.Value;
        this.head = this.head.Next;

        if (this.head != null)
            this.head.Previous = null;

        else
            this.tail = null;

        this.Count--;
        return firstEl;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
            throw new InvalidOperationException("List empty!");


        var lastEl = this.tail.Value;
        this.tail = this.tail.Previous;

        if (this.tail != null)
            this.tail.Previous = null;

        else
            this.head = null;

        this.Count--;
        return lastEl;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while(currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
       T[] copy = new T[this.Count];

        int index = 0;
        var currentNode = this.head;
        while (currentNode != null)
        {
            copy[index++] = currentNode.Value;
            currentNode = currentNode.Next;
        }
        return copy;
    }
}


public class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
