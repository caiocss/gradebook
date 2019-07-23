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
            bookCaio.ShowStatistics();
                       
        }
    }
}
