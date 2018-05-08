using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                                                  .Select(x => int.Parse(x))
                                                  .ToList();
            int len = 1;
            int bestLen = 0;
            int startPosition = 0;
            int pos = 0;

            if (numbers.Count == 1)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i-1] == numbers[i])
                {
                    len++;
                    if (len > bestLen)
                    {
                        bestLen = len;
                        pos = startPosition;
                    }
                }
                else
                {
                    startPosition = i;
                    len = 1;
                    if (len > bestLen)
                    {
                        bestLen = len;
                        pos = i;
                    }
                }
            }

            if(bestLen == 1)
                Console.WriteLine(numbers[0]);
            else
            Console.WriteLine(string.Join(" ",numbers.Skip(pos).Take(bestLen).ToList()));
        }
    }
}
