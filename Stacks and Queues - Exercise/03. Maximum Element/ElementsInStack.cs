namespace _03._Maximum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ElementsInStack
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var numbers= new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                var cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (cmd[0]==2)
                {
                    if (numbers.Count>0)
                    {
                        numbers.Pop();
                    }
                }
                else if(cmd[0]==3)
                {
                    var maxValue = numbers.Max();
                    Console.WriteLine(maxValue);
                }
                else
                {
                    numbers.Push(cmd[1]);
                }
            }
        }
    }
}
