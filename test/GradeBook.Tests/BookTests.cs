namespace GradeBook.Tests;

public class BookTests
{
    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
        // Arrange
        IBook book = new InMemoryBook("");
        
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        // Act
        var stats = book.GetStatistics();

        // Assert
        Assert.Equal(85.6, stats.Average, 1);
        Assert.Equal(90.5, stats.High);
        Assert.Equal(77.3, stats.Low);
        Assert.Equal('B', stats.Letter);
    }
}