using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;

        if (parentIndex < 0)
            return;

        int compare = this.heap[index].CompareTo(this.heap[parentIndex]);

        if (compare > 0)
        {
            this.Swap(index, parentIndex);
            this.HeapifyUp(parentIndex);
        }

    }

    private void Swap(int index, int parent)
    {
        T par = this.heap[parent];

        this.heap[parent] = this.heap[index];
        this.heap[index] = par;

    }

    public T Peek()
    {
        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count <= 0)
            throw new InvalidOperationException();

        T item = this.heap[0];

        this.Swap(0, this.heap.Count - 1);
        this.heap.RemoveAt(this.heap.Count - 1);
        this.HeapifyDown(0);

        return item;
    }

    private void HeapifyDown(int currentIndex)
    {
        while (currentIndex < this.heap.Count / 2)
        {
            int childIndex = 2 * currentIndex + 1;

            if (childIndex + 1 < this.heap.Count)
            {
                int compare = this.heap[childIndex].CompareTo(this.heap[childIndex + 1]);

                if (compare < 0)
                    childIndex++;
            }

            if (this.heap[currentIndex].CompareTo(this.heap[childIndex]) > 0)
                break;

            this.Swap(currentIndex, childIndex);
            currentIndex = childIndex;

        }
    }
}
