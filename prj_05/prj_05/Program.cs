using System;
using System.Collections.Generic;
using System.Linq;

namespace prj_05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> fibonacciList = Fibonacci.NumbersInQuantity(200);
            Console.WriteLine(fibonacciList.ExtendedToString());
            //1
            Console.WriteLine("\n1. Count of prime numbers:");
            Console.WriteLine(fibonacciList.Count(number => number.isProbablePrime()));
            //2
            Console.WriteLine("\n2. Count of numbers divided by its sum of digits:");
            Console.WriteLine(fibonacciList.Count(number => number.IsDivideBy(number.SumOfDigits())));
            //3
            Console.WriteLine("\n3. Numbers divided by 5:");
            Console.WriteLine(fibonacciList.Any(number => number.IsDivideBy(5)));
            //4
            Console.WriteLine("\n4. Square roots of numbers which contain 2:");
            Console.WriteLine(fibonacciList.Where(number => number.Contains(2)).Select(number => number.sqrt()).ExtendedToString());
            //5
            Console.WriteLine("\n5. Sorted by second digit numbers:");
            Console.WriteLine(fibonacciList.OrderByDescending(number => number.GetDigitOnIndex(1)).ExtendedToString());
            //6
            Console.WriteLine("\n6. 2 last digits of numbers divided by 3 with neighbours divided by 5:");
            List<BigInteger> tempList = fibonacciList.Where(number => number.IsDivideBy(3)).Select(number => number % 100).ToList();
            for (int i = 0; i<tempList.Count; i++)
            {
                if (!tempList.GetNeighbours(i, 5).Any(number => number.IsDivideBy(5)))
                    tempList.Remove(tempList[i]);
            }
            Console.WriteLine(tempList.ExtendedToString());
            //7
            Console.WriteLine("\n7. Number with max sum of squared digits:");
            Console.WriteLine(fibonacciList.First(n => n.SumOfSquaredDigits()==fibonacciList.Max(number => number.SumOfSquaredDigits())));
            //8
            Console.WriteLine("\n8. Average count of zeros in numbers:");
            Console.WriteLine(fibonacciList.Average(number => number.CountOfDigit(0)));

            Console.ReadKey();
        }
        
    }
}

