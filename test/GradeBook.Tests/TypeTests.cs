using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests //Whenever when you are working with something that is been defined by a class then you are working with refernce types  
    {
                [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
            
        }

        private void SetInt(ref int z)
        {
            z = 42;
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
        public void CSharpIsPassByValue() //CSharp almost always passed by value
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
        public void StringsBehaveLikeValueTypes() //Strings are immutable
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
            
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
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

            Assert.Same(book1, book2); //'Same' can be used to asses if two variable are pointing at the same value in memory
            Assert.True(Object.ReferenceEquals(book1, book2)); // This is basically showing us what is going on behind the scenes with 'Same' method.
        }


        /* public void TestTheGrade(int x)
        {
            var TestBook = new Book(x);
            
            Assert.Equal(105, x);
        }
        */

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}