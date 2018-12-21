    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var numbers = new Stack<int>(input);

            Console.WriteLine(string.Join(" ",numbers));
        }
    }

