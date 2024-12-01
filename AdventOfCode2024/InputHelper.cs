using System;
using System.IO;

namespace Utility
{
    public class InputHelper
    {
        public static string[] ReadInput(string fileName)
        {
            return File.ReadAllLines(GetPath(fileName));
        }

        private static string GetPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @$"Advent of Code/2024/{fileName}");
        }
    }
}
