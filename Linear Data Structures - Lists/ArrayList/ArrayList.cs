using System;

public class ArrayList<T>
{
    private const int InitialCapacity = 2;
    private T[] items;

    public ArrayList()
    {
        this.items = new T[InitialCapacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
                throw new ArgumentOutOfRangeException();

            return this.items[index];
        }

        set
        {
            if (index >= this.Count)
                throw new ArgumentOutOfRangeException();

            this.items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.Count == this.items.Length)
            this.Resize();

        this.items[this.Count++] = item;
    }

    private void Resize()
    {
        T[] newArr = new T[this.items.Length * 2];
        Array.Copy(this.items, newArr, this.items.Length);
        this.items = newArr;
    }

    public T RemoveAt(int index)
    {
        T removedEl = this.items[index];
        this.items[index] = default(T);
        this.Count--;
        return removedEl;
    }
}
