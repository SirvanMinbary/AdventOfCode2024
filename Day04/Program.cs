using System.IO;
using Utility;

namespace Day04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = InputHelper.ReadInput("04.txt");
            var word = "XMAS";
            var directions = new int[][]
            {
                [-1, 0],
                [ -1, 1 ],
                [ 1, 0 ],
                [ 1, 1 ],
                [ 1, -1 ],
                [ 0, -1 ],
                [ -1, -1 ],
            };

            var count = 0;

            for (int line = 0; line < input.Length; line++)
            {
                for (int column = 0; column < input[line].Length; column++)
                {
                    for (int d = 0; d < directions.Length; d++)
                    {
                        var direction = directions[d];
                        var coords = new int[] { column + direction[0], line + direction[1] };
                        Console.WriteLine($"{coords[0]}, {coords[1]}");
                        if (coords[0] < 0 || coords[0] < 0 || coords[0] + word.Length > input[column].Length || coords[1] < 0 || coords[1] == input.Length)
                        {
                            continue;
                        }

                        var isMatch = true;
                        for (int length = 1; length < word.Length; length++)
                        {
                            var letter = input[coords[1]][coords[0]];
                            if (word[length] != letter)
                            {
                                isMatch = false;
                                break;
                            }
                        }

                        if (isMatch)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        private static bool FindWord(string[] input, string word, int x, int y, int directionX, int directionY)
        {
            for (int length = 0; length < word.Length; length++)
            {
                var letter = input[x + directionX][y + directionY];
                if (word[length] != letter)
                {
                    return false;
                }
            }

            return true;
        }
    }
}