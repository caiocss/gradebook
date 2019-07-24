using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var bookCaio = new Book("Caio's grade book");
            bookCaio.AddGrade(20);
            bookCaio.AddGrade(33.2);
            bookCaio.AddGrade(3.3);
            var stats = bookCaio.GetStatistics();

            System.Console.WriteLine($"The lowest grade is: {stats.Low}");
            System.Console.WriteLine($"The highest grade is: {stats.High}");
            System.Console.WriteLine($"The average grade is: {stats.Average}");                       
        }
    }
}
