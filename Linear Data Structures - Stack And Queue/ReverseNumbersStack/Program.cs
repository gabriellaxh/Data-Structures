using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] nums = Console.ReadLine()
                                   .Split()
                                   .Select(x => int.Parse(x))
                                   .ToArray();

                Stack<int> stack = new Stack<int>();

                foreach (var num in nums)
                {
                    stack.Push(num);
                }

                Console.WriteLine(string.Join(" ", stack));
            }

            catch (FormatException)
            {
                Console.WriteLine();
            }

        }
    }
}
