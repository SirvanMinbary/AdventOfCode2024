using Utility;

namespace Day04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var input = new string[]
            //{
            //    "MMMSXXMASM",
            //    "MSAMXMSMSA",
            //    "AMXSXMAAMM",
            //    "MSAMASMSMX",
            //    "XMASAMXAMM",
            //    "XXAMMXXAMA",
            //    "SMSMSASXSS",
            //    "SAXAMASAAA",
            //    "MAMMMXMMMM",
            //    "MXMXAXMASX"
            //};
            var input = InputHelper.ReadInput("04.txt");
            var word = "XMAS";
            var directions = new int[][]
            {
                [  1,  0 ],
                [  1,  1 ],
                [  0,  1 ],
                [  1, -1 ],
                [ -1,  0 ],
                [ -1, -1 ],
                [  0, -1 ],
                [ -1,  1 ],
            };

            var count = 0;
            for (int line = 0; line < input.Length; line++)
            {
                for (int column = 0; column < input[line].Length; column++)
                {
                    for (int d = 0; d < directions.Length; d++)
                    {
                        var direction = directions[d];

                        if (FindWord(input, word, column, line, direction[0], direction[1]))
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);

            var word2 = "MAS";
            var reversed = new string(word2.Reverse().ToArray());
            var count2 = 0;
            for (int line = 1; line < input.Length - 1; line++)
            {
                for (int column = 1; column < input[line].Length - 1; column++)
                {
                    var letter = input[line][column];
                    if (letter != word2[1])
                    {
                        continue;
                    }

                    var diagonal1 = input[line - 1][column - 1].ToString()
                        + input[line][column].ToString()
                        + input[line + 1][column + 1].ToString();

                    var diagonal2 = input[line - 1][column + 1].ToString()
                        + input[line][column].ToString()
                        + input[line + 1][column - 1].ToString();
                    if ((diagonal1 == word2 || diagonal1 == reversed)
                        && (diagonal2 == word2 || diagonal2 == reversed))
                    {
                        count2++;
                    }
                }
            }
            Console.WriteLine(count2);
        }

        private static bool FindWord(string[] input, string word, int column, int line, int directionX, int directionY)
        {
            var firstLetter = input[line][column];
            if (firstLetter != word[0])
            {
                return false;
            }

            for (int length = 1; length < word.Length; length++)
            {
                var searchX = column + directionX * length;
                var searchY = line + directionY * length;
                if (searchX < 0
                    || searchX >= input[column].Length
                    || searchY < 0
                    || searchY >= input.Length)
                {
                    return false;
                }
                var letter = input[line + directionY * length][column + directionX * length];
                if (letter != word[length])
                {
                    return false;
                }
            }

            return true;
        }
    }
}