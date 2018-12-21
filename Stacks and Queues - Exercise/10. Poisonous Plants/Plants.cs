namespace _10._Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Plants
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> indexes = new List<int>();
            var days = 0;
            
            while (true)
            {
                for (int i = 0; i < plants.Count-1; i++)
                {
                    if (plants[i]<plants[i+1])
                    {
                        indexes.Add(i+1);
                    }
                }

                if (indexes.Count==0)
                {
                    break;
                }

                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    plants.RemoveAt(indexes[i]);
                }
                
                indexes.Clear();
                days++;
            }

            Console.WriteLine(days);
        }
    }
}
