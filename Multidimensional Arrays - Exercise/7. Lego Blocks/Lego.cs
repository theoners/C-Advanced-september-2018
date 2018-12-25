namespace _7._Lego_Blocks
{
    using System;
    using System.Linq;

    public class Lego
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var firstBlock = new int[rows][];
            var secondBLock = new int[rows][];

            GetBlock(firstBlock);
            GetBlock(secondBLock);
            var colLength = firstBlock[0].Length + secondBLock[0].Length;
            for (int row = 0; row < rows; row++)
            {
                if (firstBlock[row].Length + secondBLock[row].Length != colLength)
                {
                    PrintTOtalCell(firstBlock, secondBLock);
                    return;
                }
            }

            ReverseBlock(secondBLock);
            var result = SplitBlocks(firstBlock, secondBLock);
            PrintBlock(result);
        }

        private static int[][] SplitBlocks(int[][] firstBlock, int[][] secondBLock)
        {
            var result = new int[firstBlock.Length][];

            for (int row = 0; row < result.Length; row++)
            {
                int counter = 0;
                result[row]=new int[firstBlock[row].Length+secondBLock[row].Length];
                for (int i = 0; i < firstBlock[row].Length; i++)
                {
                    result[row][i] = firstBlock[row][i];
                    counter = i;
                }
                for (int j = 0; j < secondBLock[row].Length; j++)
                {
                    result[row][counter+ 1 + j] = secondBLock[row][j];
                }
            }

            return result;
        }

        private static void ReverseBlock(int[][] secondBLock)
        {
            for (int row = 0; row < secondBLock.Length; row++)
            {
                var reversedRow = secondBLock[row].Reverse().ToArray();
                secondBLock[row] = reversedRow;
            }
        }

        private static void PrintTOtalCell(int[][] firstBlock, int[][] secondBLock)
        {
            var totalCell = 0;
            for (int i = 0; i < firstBlock.Length; i++)
            {
                totalCell += firstBlock[i].Length + secondBLock[i].Length;
            }
            Console.WriteLine($"The total number of cells is: {totalCell}");
        }

        private static void PrintBlock(int[][] firstBlock)
        {
            for (int row = 0; row < firstBlock.Length; row++)
            {
                Console.Write($"[{string.Join(", ", firstBlock[row])}]");
                Console.WriteLine();
            }
        }

        private static void GetBlock(int[][] block)
        {
            for (int row = 0; row < block.Length; row++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                block[row] = input;
            }
        }
    }
}
