namespace _6._Target_Practice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new char[matrixSize[0]][];
            var text = Console.ReadLine().ToCharArray();

            GetMatrix(matrix, text, matrixSize[1]);

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var row = input[0];
            var col = input[1];
            var radius = input[2];

            ReplaceChar(matrix, row, col, radius);
            FallingChar(matrix);
            PrintMatrix(matrix);
        }

        private static void FallingChar(char[][] matrix)
        {
            for (int col = matrix[0].Length - 1; col >= 0; col--)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (matrix[row][col] == ' ')
                    {
                        for (int i = row; i >= 0; i--)
                        {
                            if (matrix[i][col] != ' ')
                            {
                                matrix[row][col] = matrix[i][col];
                                matrix[i][col] = ' ';
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ReplaceChar(char[][] matrix, int BOmbRow, int BombCol, int radius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (Math.Pow((row - BOmbRow),2) + Math.Pow((col - BombCol),2) <= Math.Pow(radius,2))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static void GetMatrix(char[][] matrix, char[] text, int size)
        {
            var rowCounter = 1;
            var charCounter = 0;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[size];

                if (rowCounter % 2 == 1)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = text[charCounter % text.Length];
                        charCounter++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = text[charCounter % text.Length];
                        charCounter++;
                    }
                }

                rowCounter++;
            }
        }
    }
}