using System;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class Book
  {
    private List<double> Grades { get; set; }
    public string Name { get; set; }
    readonly string category = "science";
    public event GradeAddedDelegate GradeAdded;

    public Book(string name)
    {
      this.Name = name;
      this.Grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
      if (grade >= 0 && grade <= 100)
      {
        this.Grades.Add(grade);
        if(GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }

      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
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

      switch (result.Average)
      {
        case var d when d >= 90.0:
          result.Letter = 'A';
          break;
        case var d when d >= 80.0:
          result.Letter = 'B';
          break;
        case var d when d >= 70.0:
          result.Letter = 'C';
          break;
        case var d when d >= 60.0:
          result.Letter = 'D';
          break;
        case var d when d <= 50.0:
          result.Letter = 'F';
          break;
      }

      return result;
    }
  }
}