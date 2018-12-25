namespace _1._Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    public class Palindromes
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string text = "";
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    text += (char)(97 + row);
                    text += (char)(97 + col+row);
                    text += (char)(97 + row);
                    matrix[row, col] = text;
                    text = "";
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }

                Console.WriteLine();
            }
        }
    }
}
