using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AVL<int> avl = new AVL<int>();
        avl.Insert(5);
        avl.Insert(3);
        avl.Insert(1);
        avl.Insert(4);
        avl.Insert(8);
        avl.Insert(9);

        // Act
        avl.Delete(5);
        List<int> result = new List<int>();
        avl.EachInOrder(result.Add);

        // Assert
        int[] expectedNodes = new int[] { 1, 3, 4, 8, 9 };
       // CollectionAssert.AreEqual(expectedNodes, result.ToArray());

       // Console.WriteLine();
    }
}
