using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbersArray = new[] {10.1, 10.1 };
            var numbersList = new List<double>() {10.1 , 10.1, 33.2, 40.2, 3.3};

            double result = 0;

            foreach (double number in numbersList)
            {
                result += number;
            }
            result = result / numbersList.Count;

            Console.WriteLine($"The average result is: {result:N1}");

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            }
            else
            {
                Console.WriteLine($"Hello!");
            }            
        }
    }
}
