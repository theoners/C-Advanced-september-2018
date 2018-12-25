namespace _11._Parking_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystem
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var parking = new int[matrixSize[0]][];
            var createdRow = new List<int>();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "stop")
                {
                    break;
                }

                var entryRow = int.Parse(input[0]);
                var parkSpotRow = int.Parse(input[1]);
                var parkSpotCol = int.Parse(input[2]);
                if (!createdRow.Contains(parkSpotRow))
                {
                    createdRow.Add(parkSpotRow);
                    parking[parkSpotRow] = new int[matrixSize[1]];
                    parking[parkSpotRow][0] = 1;
                }
                if (parking[parkSpotRow].Contains(0))
                {
                    var cellCount = SearchSpot(parking, entryRow, parkSpotRow, parkSpotCol);
                    Console.WriteLine(cellCount);
                    cellCount = 0;
                }
                else
                {
                    Console.WriteLine($"Row {parkSpotRow} full");
                }
            }
        }

        private static int SearchSpot(int[][] parking, int entryRow, int parkSpotRow, int parkSpotCol)
        {
            var steps = Math.Abs(entryRow - parkSpotRow) + parkSpotCol + 1;
            if (parking[parkSpotRow][parkSpotCol] == 0)
            {
                parking[parkSpotRow][parkSpotCol] = 1;
            }
            else
            {
                steps = SearchPlace(parking, parkSpotRow, parkSpotCol, steps);
            }

            return steps;
        }

        private static int SearchPlace(int[][] parking, int parkSpotRow, int parkSpotCol, int steps)
        {
            var stepLeft = 0;
            var stepRight = 0;
            for (int i = parkSpotCol - 1; i >= 1; i--)
            {
                if (parking[parkSpotRow][i] == 0)
                {
                    stepLeft = parkSpotCol - i;
                    break;
                }
            }

            for (int i = parkSpotCol + 1; i < parking[parkSpotRow].Length; i++)
            {
                if (parking[parkSpotRow][i] == 0)
                {
                    stepRight = i - parkSpotCol;
                    break;
                }
            }

            if (stepLeft != 0 && stepRight != 0)
            {
                if (stepLeft <= stepRight)
                {
                    parking[parkSpotRow][parkSpotCol - stepLeft] = 1;
                    return steps - stepLeft;

                }
                else
                {
                    parking[parkSpotRow][parkSpotCol + stepRight] = 1;
                    return steps + stepRight;
                }
            }

            if (stepLeft==0)
            {
                parking[parkSpotRow][parkSpotCol + stepRight] = 1;
                return steps + stepRight;
            }
            else
            {
                parking[parkSpotRow][parkSpotCol - stepLeft] = 1;
                return steps - stepLeft;
            }
            
        }
    }
}
