namespace _12._String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StringRotation
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Regex regex = new Regex(@"[0-9]+");
            var degrees = int.Parse(regex.Match(input).Value);
            Queue<string> allWord = new Queue<string>();
            var length = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input.Length > length)
                {
                    length = input.Length;
                }
                allWord.Enqueue(input);
            }

            var rotationCount = (degrees / 90)%4;
           

            if (rotationCount == 0)
            {
                while (allWord.Count != 0)
                {
                    Console.WriteLine(allWord.Dequeue().PadRight(length));
                }
            }

            else if (rotationCount == 1)
            {
                var matrix = new char[length, allWord.Count];
                var col = 0;
                while (allWord.Count != 0)
                {
                    var word = allWord.Dequeue().PadRight(length);
                    
                    for (int i = 0; i < word.Length; i++)
                    {
                        matrix[i, col] = word[i];
                    }

                    col++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        Console.Write(matrix[i, j]);
                    }

                    Console.WriteLine();
                }
            }
            else if (rotationCount == 2)
            {
                var matrix = new char[allWord.Count,length];
                var row = matrix.GetLength(0)-1;
                
                while (allWord.Count != 0)
                {
                    var col = matrix.GetLength(1) - 1;
                    var word = allWord.Dequeue().PadLeft(length);

                    for (int i = 0; i < word.Length; i++)
                    {
                        matrix[row,col--] = word[i];
                    }

                    row--;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j <matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j]);
                    }

                    Console.WriteLine();
                }
            }
            else if (rotationCount == 3)
            {
                var matrix = new char[length, allWord.Count];
                var col = 0;
                
                while (allWord.Count != 0)
                {
                    var row = matrix.GetLength(0)-1;
                    var word = allWord.Dequeue().PadRight(length);

                    for (int i = 0; i < word.Length; i++)
                    {
                        matrix[row, col] = word[i];
                        row--;
                    }
                    col++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i,j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
