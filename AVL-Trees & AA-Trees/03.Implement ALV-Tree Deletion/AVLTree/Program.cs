using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AVL<int> avl = new AVL<int>();
        for (int i = 1; i < 10; i++)
        {
            avl.Insert(i);
        }

        avl.Delete(4);

        var root = avl.Root;
        
        //Assert.AreEqual(5, root.Value);
        //Assert.AreEqual(4, root.Height);
    }
}
