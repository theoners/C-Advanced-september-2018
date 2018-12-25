namespace _5._Rubiks_Matrix
{
    using System;
    using System.Linq;

    public class Rubiks
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[matrixSize[0]][];
            var number = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row]= new int[matrixSize[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = number;
                    number++;
                }
            }

            var cmdCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < cmdCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var colOrRow = int.Parse(input[0]);
                var direction = input[1];
                var count = int.Parse(input[2]);

               ArraySifting(matrix, direction, colOrRow, count);
            }

            var counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        RearangeMatrix(matrix, col, row, counter);
                        counter++;

                    }
                }
            }
        }

        private static void RearangeMatrix(int[][] matrix, int col, int row, int counter)
        {
            for (int newRow = 0; newRow < matrix.Length; newRow++)
            {
                for (int newCol = 0; newCol < matrix[row].Length; newCol++)
                {
                    if (matrix[newRow][newCol] == counter)
                    {
                        Console.WriteLine($"Swap ({row}, {col}) with ({newRow}, {newCol})");
                        int tempNumber = matrix[row][col];
                        matrix[row][col] = matrix[newRow][newCol];
                        matrix[newRow][newCol] = tempNumber;
                        return;
                    }
                }
            }
        }

        private static void ArraySifting(int[][] matrix, string direction, int colOrRow, int count)
        {
            if (direction == "down" || direction == "up")
            {
                if (direction == "down")
                {
                    count = -count;
                }
                var currentCol = new int[matrix[0].Length];

                for (int row = 0; row < matrix.Length; row++)
                {
                    currentCol[row] = matrix[row][colOrRow];
                }

                var shiftedCol = new int[currentCol.Length];
                for (int i = 0; i < currentCol.Length; ++i)
                {
                    shiftedCol[(i + currentCol.Length - count%currentCol.Length) % currentCol.Length] = currentCol[i];
                }

                for (int row = 0; row < matrix.Length; row++)
                {
                    matrix[row][colOrRow] = shiftedCol[row];
                }
            }

            else
            {
                if (direction == "right")
                {
                    count = -count;
                }
                var currentRow = new int[matrix.Length];

                for (int col = 0; col < matrix[0].Length; col++)
                {
                    currentRow[col] = matrix[colOrRow][col];
                }

                var shiftedCol = new int[currentRow.Length];
                for (int i = 0; i < currentRow.Length; ++i)
                {
                    shiftedCol[(i + currentRow.Length - count%currentRow.Length) % currentRow.Length] = currentRow[i];
                }

                for (int col = 0; col < matrix[0].Length; col++)
                {
                    matrix[colOrRow][col] = shiftedCol[col];
                }
            }
        }
    }
}
