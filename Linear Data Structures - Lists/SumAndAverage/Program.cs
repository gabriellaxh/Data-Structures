using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAverage
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> nums = Console.ReadLine().Split(" ")
                                           .Select(x => int.Parse(x))
                                           .ToList();
                int sum = 0;
                foreach (var num in nums)
                {
                    sum += num;
                }
                double average = ((double)sum / nums.Count);

                Console.WriteLine($"Sum={sum}; Average={average:f2}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Sum=0; Average=0.00");      
            }
           
        }
    }
}
