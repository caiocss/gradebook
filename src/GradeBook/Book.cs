using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    private List<double> Grades { get; set; }
    private string Name { get; set; }

    public Book(string name)
    {
      this.Name = name;
      this.Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
      this.Grades.Add(grade);
    }

    public void ShowStatistics()
    {
      if (this.Grades.Count > 0)
      {
        double result = 0;
        double highGrade = double.MinValue;
        double lowGrade = double.MaxValue;
        foreach (double number in this.Grades)
        {
          highGrade = Math.Max(number, highGrade);
          lowGrade = Math.Min(number, lowGrade);
          result += number;
        }
        result = result / this.Grades.Count;

        Console.WriteLine($"The average result is: {result:N1}");
        Console.WriteLine($"The lowest result is: {lowGrade}");
        Console.WriteLine($"The highest result is: {highGrade}");
      }
      else
      {
        Console.WriteLine($"Don't have any grades in {this.Name}");
      }
    }
  }
}