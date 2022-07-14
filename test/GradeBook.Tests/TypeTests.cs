namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    [Fact]
    public void GetBooksReturnDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    /**
    * Invalid test for now
    [Fact]
    public void CSharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
    }
    */

    [Fact]
    public void CSharpCanPassByRef()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(42, x);
    }

    [Fact]
    public void StringsBehaveLikeValueTypes() {
        string name = "Ricardo";
        var upper = MakeUppercase(name);

        Assert.Equal("Ricardo", name);
        Assert.Equal("RICARDO", upper);
    }

    [Fact]
    public void WriteLogDelegateCanPointToMethod() {
        WriteLogDelegate log;
        log = ReturnMessage;

        var result = log("Hello!");
        Assert.Equal("Hello!", result);
    }

    string ReturnMessage(string message) {
        return message;
    }

    private string MakeUppercase(string parameter) {
        return parameter.ToUpper();
    }

    Book GetBook(string name) {
        return new Book(name);
    }

    private void SetName(Book book, string name) {
        book.Name = name;
    }

    private void GetBookSetName(ref Book book, string name) {
        book = new Book(name);
    }

    private int GetInt() {
        return 3;
    }

    private void SetInt(ref int x) {
        x = 42;
    }
}