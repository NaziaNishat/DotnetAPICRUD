using DataAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitTest
{
    public class MockGenericRepository
    {
        List<Book> booklist = new List<Book>();


        public MockGenericRepository()
        {
            var mockrepo = new Mock<IGenericRepository>();

            booklist.Add(new Book { id = 1, title = "nishat1", author = "author1" });
            booklist.Add(new Book { id = 2, title = "nishat2", author = "author2" });
            booklist.Add(new Book { id = 3, title = "nishat3", author = "author3" });

            var results = from book in booklist
                          where book.id.Equals(1)
                          select book;

            mockrepo.Setup(e => e.get<Book>(It.IsAny<int>())).Returns(
                (int id) =>
                {
                    var bookObj = booklist.FirstOrDefault(e => e.id == id);
                    return bookObj;
                });

            mockrepo.Setup(e => e.add<Book>(It.IsAny<Book>())).Returns(
                    (Book book) =>
                    {
                        return book;
                    });
        }


    }
}
