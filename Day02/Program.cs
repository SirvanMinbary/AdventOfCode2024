using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Day02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = InputHelper.ReadInput("02.txt");
            RunTestInput();
            Part1(input);
            Part2(input);
        }

        private static void Part1(string[] input)
        {
            var safeSum = 0;

            foreach (var report in input)
            {
                var split = report.Split().Select(int.Parse).ToList();
                if (IsReportSafe(split))
                {
                    safeSum++;
                }
            }

            Console.WriteLine(safeSum);
        }

        private static void Part2(string[] input)
        {
            var safeSum = 0;
            foreach (var report in input)
            {
                var split = report.Split().Select(int.Parse).ToList();
                if (IsReportSafe(split))
                {
                    safeSum++;
                }
                else
                {
                    for (int i = 0; i < split.Count; i++)
                    {
                        var copy = split.ToList();
                        copy.RemoveAt(i);
                        if (IsReportSafe(copy))
                        {
                            safeSum++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(safeSum);
        }

        private static bool IsReportSafe(List<int> report)
        {
            if (!AllAreAscending(report) && !AllAreDescending(report))
            {
                return false;
            }

            for (int i = 0; i < report.Count; i++)
            {
                if (i == report.Count - 1)
                {
                    break;
                }

                var diff = Math.Abs(report[i] - report[i + 1]);
                if (diff > 3 || diff == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AllAreAscending(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] > list[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AllAreDescending(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] < list[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void RunTestInput()
        {
            var input = new string[]
            {
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
            };

            Part1(input);
            Part2(input);
        }
    }
}