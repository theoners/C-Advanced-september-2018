namespace _3._Decimal_to_Binary_Converter
{
    using System;
    using System.Collections.Generic;

    public class BinaryConverter
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var binaryNumber = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (number != 0)
            {
                int result = number % 2;
                binaryNumber.Push(result);
                number /= 2;

            }

            while (binaryNumber.Count != 0)
            {
                Console.Write(binaryNumber.Pop());
            }

            Console.WriteLine();
        }
    }
}
