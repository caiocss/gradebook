using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
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

    public Statistics GetStatistics()
    {

      var result = new Statistics();
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach (double grade in this.Grades)
      {
        result.High = Math.Max(grade, result.High);
        result.Low = Math.Min(grade, result.Low);
        result.Average += grade;
      }

      result.Average /= this.Grades.Count;

      return result;
    }
  }
}