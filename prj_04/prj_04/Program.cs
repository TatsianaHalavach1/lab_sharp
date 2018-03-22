using lib_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using lib_NumberRows;

namespace prj_04
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demonstration of Point class
            Console.WriteLine("\nDemonstration of Point class");
            Point point1 = new Point(-5.5, 8);
            Point point2 = new Point(-5.5, 8);
            Point point3 = new Point(2, 3);
            try
            {
                Point point4 = new Point(double.PositiveInfinity, 3);
            }
            catch (PointCoordinateException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"Points {point1} and {point2} are equal: {point1.Equals(point2)}");
            Console.WriteLine($"Distance between points {point1} and {point3} is {point1.DistanceTo(point3)}");

            //Demonstration of Factorial class
            Console.WriteLine("\nDemonstration of Factorial class");
            int n = 7, N = 720;
            try
            {
                Console.WriteLine($"{n}! = {Factorial.FactorialOf(n)}");
                Console.WriteLine($"{N} is factorial: {Factorial.IsFactorial(N)}");
                Console.WriteLine($"{Factorial.ReverseFactorialOf(N)}! = {N}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            //Demonstration of Fibonacci class
            Console.WriteLine("\nDemonstration of Fibonacci class");
            Fibonacci fibonacci1 = new Fibonacci();
            Fibonacci fibonacci2 = new Fibonacci();
            Fibonacci fibonacci3 = new Fibonacci();
            int maxFibonacci = 20;
            int countFibonacci = 87;
            long numberForCheckingFibonacci = 4181;
            Console.WriteLine($"Fibonacci row towards {maxFibonacci}:\n{fibonacci1.NumbersTo(maxFibonacci).ExtendedToString()}");
            Console.WriteLine($"\nFibonacci row ({countFibonacci} numbers):\n{fibonacci2.NumbersInQuantity(countFibonacci).ExtendedToString()}");
            Console.WriteLine($"\n{numberForCheckingFibonacci} is from Fibonacci row: {fibonacci3.IsFibonacci(numberForCheckingFibonacci)}");

            //Demonstration of class with number of instances
            Console.WriteLine("\nDemonstration of class with number of instances");
            List<Person> people = new List<Person>
            {
                new Person("Ivan Petrov", new DateTime(1993, 5, 23)),
                new Person("Sofia Orlova", new DateTime(1978, 12, 2), 1),
                new Person("Gleb Palochkin", new DateTime(1988, 2, 23), 0)
            };
            Console.WriteLine(string.Join("\n", people));
            Console.WriteLine("Current population is {0}", Person.Population);

            Console.ReadKey();
        }
    }
}
