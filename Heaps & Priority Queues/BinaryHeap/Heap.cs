using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        ConstructHeap(arr);
    }

    private static void ConstructHeap(T[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Swap(arr, 0, i);
            HeapifyDown(arr, 0, i);
        }
    }

    private static void HeapifyDown(T[] arr, int currentIndex, int length)
    {
        while (currentIndex < length / 2)
        {
            int childIndex = 2 * currentIndex + 1;

            if (childIndex + 1 < length)
            {
                int compare = arr[childIndex].CompareTo(arr[childIndex + 1]);

                if (compare < 0)
                    childIndex++;
            }

            if (arr[currentIndex].CompareTo(arr[childIndex]) > 0)
                break;

            Swap(arr,currentIndex, childIndex);
            currentIndex = childIndex;
        }
    }

    private static void Swap(T[] arr,int index, int parent)
    {
        T par = arr[parent];

        arr[parent] = arr[index];
        arr[index] = par;

    }
}
