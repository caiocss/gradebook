using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {

            // Arrange - Reuni e organiza os dados, objetos e valores que vamos utilizar para o teste.
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act - É aqui que inomcamos o método e calculamos o resultado real
            var result = book.GetStatistics();

            //Assert - Onde você afirma algo sobre o resultado do act.
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(85.6, result.Average, 1);
        }
    }
}
