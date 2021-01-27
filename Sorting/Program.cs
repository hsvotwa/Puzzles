using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your string:");
            string str = Console.ReadLine();
            Console.WriteLine($"In-built sorting output is: { sortStrBuiltIn(str) }");
            Console.WriteLine($"Custom sorting output is: { sortStrCustom(str) }");
            Console.ReadLine();
        }

        public static string sortStrBuiltIn(string inStr)
        {
            if (string.IsNullOrEmpty(inStr))
            {
                return string.Empty;
            }
            List<char> allChars = inStr.ToLower().ToCharArray().ToList();
            allChars.RemoveAll(item => char.IsPunctuation(item));
            return string.Join("", allChars.OrderBy(item => item).ToArray()).Trim();
        }

        private static char[] allCharsArr { get; set; }

        private static string sortStrCustom(string inStr)
        {
            List<char> allChars = inStr.ToLower().ToCharArray().ToList();
            allChars.RemoveAll(item => ! char.IsLetterOrDigit(item));
            allCharsArr = allChars.ToArray();
            int length = allCharsArr.Length;
            sortStr(0, length - 1);
            return string.Join("", allCharsArr);
        }

        public static void sortStr(int firstIndex, int lastIndex)
        {
            int i = firstIndex;
            int j = lastIndex;
            char tempChar;
            int mid = (firstIndex + lastIndex) / 2; //Determine midpoint
            while (i <= j)
            {
                while (allCharsArr[ i ] < allCharsArr[ mid ])
                {
                    i++;
                }
                while (allCharsArr[ j ] > allCharsArr[ mid ])
                {
                    j--;
                }
                if (i <= j)
                {
                    tempChar = allCharsArr[ i ];
                    allCharsArr[ i ] = allCharsArr[ j ];
                    allCharsArr[ j ] = tempChar;
                    i++;
                    j--;
                }
            }
            if (firstIndex < j)
            { //Recursion
                sortStr(firstIndex, j);
            }
            if (i < lastIndex)
            { //Recursion
                sortStr(i, lastIndex);
            }
        }
    }
}
