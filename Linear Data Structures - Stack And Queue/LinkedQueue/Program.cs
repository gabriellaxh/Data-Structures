using System;

namespace LinkedQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(2);
            queue.Enqueue(4);
            queue.Enqueue(6);
            queue.Enqueue(8);
            queue.Dequeue();
            queue.Dequeue();
            var array = queue.ToArray();
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
