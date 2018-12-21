namespace _05._Sequence_With_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var result = new List<long>();
            queue.Enqueue(number);
            result.Add(number);

            for (int i = 0; i < 17; i++)
            {
                var currentNumber = queue.Dequeue();
                var a = currentNumber + 1;
                var b = currentNumber * 2 + 1;
                var c = currentNumber + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                result.Add(a);
                result.Add(b);
                result.Add(c);


            }

            Console.WriteLine(string.Join(" ", result.Take(50)));
        }
    }
}
