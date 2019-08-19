using System;
using Xunit;

namespace GradeBook.Tests
{
  public delegate string WriteLogDelegate(string logMess);

  public class TypeTests
  {    
    int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
      WriteLogDelegate log = ReturnMessage;
      log += incrementCount;

      var result = log("Hi!");
      Assert.Equal(2, count);
    }
    string ReturnMessage(string mess)
    {
      ++count;
      return mess;
    }
    string incrementCount(string mess)
    {
      ++count;
      return mess.ToLower();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      int x = GetInt();
      SetInt(ref x);
      Assert.Equal(42, x);
    }

    private void SetInt(ref int z)
    {
      z = 42;
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Caio";
        string upper = MakeUpperCase(name);

        Assert.Equal("Caio", name);
        Assert.Equal("CAIO", upper);
    }

    private string MakeUpperCase(string param) {
        return param.ToUpper();
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");
      Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");
      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      SetName(book1, "New Name");

      Assert.Equal("New Name", book1.Name);
    }
    
    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
