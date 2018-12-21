namespace _08._Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class Fibonacci
    {
         public static void Main()
         {
             var n = long.Parse(Console.ReadLine());
             var fibonacciStack = new Stack<long>();
             fibonacciStack.Push(0);
             fibonacciStack.Push(1);
             
            for (int i = 0; i <= n-2; i++)
             {
                 var currentNumber = fibonacciStack.Pop();
                 var previousNumber = fibonacciStack.Peek();
                 fibonacciStack.Push(currentNumber);
                 var numberForAdd = currentNumber + previousNumber;
                 fibonacciStack.Push(numberForAdd);
             }

             Console.WriteLine(fibonacciStack.Pop());
         }
    }
}
