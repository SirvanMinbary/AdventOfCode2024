using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Day01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = InputHelper.ReadInput("01.txt");

            var list1 = new List<int>();
            var list2 = new List<int>();

            foreach (var line in input)
            {
                var split = line.Split("   ");
                list1.Add(int.Parse(split[0]));
                list2.Add(int.Parse(split[1]));
            }

            list1.Sort();
            list2.Sort();
            var sum = 0;
            var similarity = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                var left = list1[i];
                var right = list2[i];
                sum += Math.Abs(left - right);

                var matches = list2.Count(n => n == left);
                similarity += left * matches;
            }

            Console.WriteLine(sum);
            Console.WriteLine(similarity);

        }
    }
}