using System;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(4);
            stack.Push(2);
           
            stack.Pop();

            int[] array = stack.ToArray();
            Console.WriteLine(string.Join(", ", array));



        }
    }
}
