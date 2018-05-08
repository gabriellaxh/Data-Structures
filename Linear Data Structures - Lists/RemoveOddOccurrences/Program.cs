using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveOddOccurrences
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                          .Split()
                                          .Select(x => int.Parse(x))
                                          .ToList();
            Dictionary<int, int> oddOccur = new Dictionary<int, int>();


            for (int i = 0; i < numbers.Count; i++)
            {
                if (!oddOccur.ContainsKey(numbers[i]))
                    oddOccur[numbers[i]] = 1;

                else
                    oddOccur[numbers[i]]++;
            }

            foreach (var num in oddOccur)
            {
                if(num.Value % 2 == 1)
                {
                    numbers.RemoveAll(x => x == num.Key);
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
