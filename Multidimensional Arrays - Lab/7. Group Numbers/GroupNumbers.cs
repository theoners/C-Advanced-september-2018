namespace _7._Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            List<int> remainderZero = new List<int>();
            List<int> remainderOne = new List<int>();
            List<int> remainderTwo = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                
                if (numbers[i]%3==0)
                {
                    remainderZero.Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i])%3==1)
                {
                    remainderOne.Add(numbers[i]);
                }
                else
                {
                    remainderTwo.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", remainderZero));
            Console.WriteLine(string.Join(" ", remainderOne));
            Console.WriteLine(string.Join(" ", remainderTwo));
        }
    }
}
