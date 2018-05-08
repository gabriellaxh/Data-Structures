using ReversedList;
using System;

namespace ImplementReverseList
{
    public class Program
    {
        static void Main(string[] args)
         {
            var list = new ReversedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.RemoveAt(3);
            list.RemoveAt(4);

            for (int i = list.Count-1; i >= 0; i--)
            {
              Console.Write($"{list[i] + " "}");
            }
            Console.WriteLine();
        }
    }
}
