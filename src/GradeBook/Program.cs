using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {        
        static void Main(string[] args)
    {
      Console.WriteLine("Digite as notas do aluno, tecle a letra 'q' para finalizar e ver os resultados...");
      Console.WriteLine("==================================================================================");
      Console.WriteLine("==================================================================================");
      Console.WriteLine("");
      var bookCaio = new Book("Caio's grade book");
      bookCaio.GradeAdded += OnGradeAdded;

      int count = 1;
      EnterGrades(bookCaio, ref count);

      Console.WriteLine();
      Console.WriteLine("Results:");
      Console.WriteLine("===============================");

      var stats = bookCaio.GetStatistics();
      System.Console.WriteLine($"The Book Name is: {bookCaio.Name}");
      System.Console.WriteLine($"The lowest grade is: {stats.Low}");
      System.Console.WriteLine($"The highest grade is: {stats.High}");
      System.Console.WriteLine($"The average grade is: {stats.Average}");
      System.Console.WriteLine($"The letter grade is: {stats.Letter}");
    }

    private static void EnterGrades(Book book, ref int count)
    {
      string input;
      while (true)
      {
        Console.WriteLine($"Digite a nota (notas adicionadas: {count}) ou digite q para sair:");

        input = Console.ReadLine();
        if (input == "q" || input == "Q")
          break;

        try
        {
          double grade = double.Parse(input);
          book.AddGrade(grade);
          count++;
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine($"Input invalido: {ex.Message}");
          continue;
        }
        catch (FormatException ex)
        {
          Console.WriteLine($"Input invalido: {ex.Message}");
          continue;
        }
      }
    }

    static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade as added");
        }
    }
}
