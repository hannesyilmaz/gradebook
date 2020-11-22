using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatedsAnAverageGrade()
        {
            //arrange (this is where you put together all your test data and u arrange the objects and the values u r going to use )
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act (this is where u invoke a method to perfom a computation that produces a result)
            var result = book.GetStatistics();
        

            // assert (where u assert something about  the value that you compute in arrnage)
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('A', result.Letter);
        }
    }
}