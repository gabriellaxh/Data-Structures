using System;

namespace ImplementArray_BasedStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(1);
            Console.WriteLine(arrayStack.Pop());
        }
    }
}
