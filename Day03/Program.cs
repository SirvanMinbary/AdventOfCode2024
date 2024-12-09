using System.Text.RegularExpressions;
using Utility;

namespace Day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = InputHelper.ReadInput("03.txt");
            var sum = 0;

            foreach (var line in input)
            {
                var matches = Regex.Matches(line, @"(mul\(\d+,\d+\))");

                foreach (Match match in matches)
                {
                    sum += MultiplyInstruction(match);
                }
            }
            Console.WriteLine(sum);

            var sum2 = 0;
            var isEnabled = true;
            foreach (var line in input)
            {
                var matches = Regex.Matches(line, @"(mul\(\d+,\d+\))|(do\(\))|\b(don't\(\))");

                foreach (Match match in matches)
                {
                    if (match.Value == "do()")
                    {
                        isEnabled = true;
                    }
                    else if (match.Value == "don't()")
                    {
                        isEnabled = false;
                    }
                    else if (isEnabled)
                    {
                        sum2 += MultiplyInstruction(match);
                    }
                }
            }
            Console.WriteLine(sum2);
        }

        private static int MultiplyInstruction(Match match)
        {
            var splitIndex = match.Value.IndexOf(',');
            var first = int.Parse(match.Value[4..splitIndex]);
            var second = int.Parse(match.Value[(splitIndex + 1)..^1]);
            return first * second;
        }
    }
}
