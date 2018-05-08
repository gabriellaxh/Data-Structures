using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOfOccurrences
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(x => int.Parse(x))
                                            .ToArray();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!dict.ContainsKey(numbers[i]))
                    dict[numbers[i]] = 1;

                else
                    dict[numbers[i]]++;
            }
            foreach (var num in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{num.Key} -> {num.Value} times");
            }
        }
    }
}
