using System;
using System.ComponentModel.DataAnnotations;

namespace Minesweeper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[] array1 = "xOOxxxOO".ToCharArray();
            char[] array2 = "OOOOxOxx".ToCharArray();
            char[] array3 = "xxOxxOOO".ToCharArray();
            char[] array4 = "OxOOOxxx".ToCharArray();
            char[] array5 = "OOxxxxOx".ToCharArray();
            char[] array6 = "xOxxxOxO".ToCharArray();
            char[] array7 = "OOOxOxOx".ToCharArray();
            char[] array8 = "xOxxOxOx".ToCharArray();
            Solution(new char[8][] { array1, array2, array3, array4, array5, array6, array7, array8 });
        }

        internal static void Solution(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != 'x')
                    {
                        char[]? first = null;
                        char[]? last = null;
                        if (i != 0)
                            first = matrix[i - 1];
                        if (i != matrix.Length - 1)
                            last = matrix[i + 1];
                        matrix[i][j] = char.Parse(CountMines(first, matrix[i], last, j).ToString());
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    Console.Write(matrix[i][j]);
                Console.WriteLine();
            }
        }

        internal static int CountMines(char[]? line1, char[] line2, char[]? line3, int position)
        {
            int count = 0;
            if (line1 != null)
            {
                if (position != 0 && line1[position - 1] == 'x')
                    count++;
                if (line1[position] == 'x')
                    count++;
                if (position != line2.Length - 1 && line1[position + 1] == 'x')
                    count++;
            }
            if (line3 != null)
            {
                if (position != 0 && line3[position - 1] == 'x')
                    count++;
                if (line3[position] == 'x')
                    count++;
                if (position != line2.Length - 1 && line3[position + 1] == 'x')
                    count++;
            }
            if (position != 0 && line2[position - 1] == 'x')
                count++;
            if (position != line2.Length - 1 && line2[position + 1] == 'x')
                count++;
            return count;
        }
    }
}

