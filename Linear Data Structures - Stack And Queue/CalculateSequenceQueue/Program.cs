using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculateSequenceQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            long s1 = long.Parse(Console.ReadLine());

            Queue<long> queue = new Queue<long>();
            queue.Enqueue(s1);

            for (int i = 0; i < 50; i++)
            {
                long current = queue.Dequeue();
                Console.Write(current + ", ");

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
            Console.WriteLine();
        }
    }
}