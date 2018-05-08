using System;

namespace Fibonacci
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci(int.Parse(Console.ReadLine())));
        }

        public static int Fibonacci(int n)
        {
            if (n < 2)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
