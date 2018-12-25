namespace _9._Crossfire
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CrossFire
    {
        public static void Main()
        {
            var size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var field = new List<List<int>>();

            GetMatrix(field, size);
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input== "Nuke it from orbit")
                {
                    break;
                }

                var commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var bombRow = commands[0];
                var bombCol = commands[1];
                var BombRadius = commands[2];

                RemoveNumbers(field, bombRow, bombCol, BombRadius);
                
            }
            PrintMatrix(field);
        }

        private static void RemoveNumbers(List<List<int>> field, int bombRow, int bombCol, int bombRadius)
        {
            for (int row = bombRow-bombRadius; row <= bombRow+bombRadius; row++)
            {
                if (IsValidRow(row,field,bombCol))
                {
                    field[row][bombCol] = 0;
                }
            }

            for (int col = bombCol-bombRadius; col <= bombCol + bombRadius; col++)
            {
                if (IsValidRow(bombRow,field,col))
                {
                    field[bombRow][col] = 0;
                }
            }
            
            for (int row = 0; row < field.Count; row++)
            {
                field[row].RemoveAll(x => x == 0);

                if (field[row].Count==0)
                {
                    field.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsValidRow(int row,List<List<int>> field,int bombCol)
        {
            return row >= 0 && row < field.Count && bombCol>=0 && bombCol<field[row].Count;
        }

        private static void PrintMatrix(List<List<int>> field)
        {
            foreach (var number in field)
            {
                Console.WriteLine(string.Join(" ",number));
            }
        }

        private static void GetMatrix(List<List<int>> field, int[] size)
        {
            var counter = 1;

            for (int row = 0; row < size[0]; row++)
            {
                var numbers = new List<int>();

                for (int col = 0; col < size[1]; col++)
                {
                    numbers.Add(counter++);
                }
                field.Add(numbers);
            }
        }
    }
}

