using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        public List<Book> bookList = new List<Book>();

        public Repository()
        {
            bookList.Add(new Book { id = 1, title = "hello", author = "author1" });
            bookList.Add(new Book { id = 2, title = "hi", author = "author2" });
        }

        public void add(Book book)
        {
            book.id = bookList.Max(e => e.id) + 1;
            bookList.Add(book);
        }

        public void delete(Book book)
        {
            bookList.Remove(book);
        }

        public Book get(int id)
        {
            return bookList.FirstOrDefault(e => e.id == id);

        }

        public List<Book> getAll()
        {
            return bookList;
        }
    }
}
