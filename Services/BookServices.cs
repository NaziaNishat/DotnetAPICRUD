using DataAccess;
using System;
using System.Collections.Generic;

namespace Services
{
    public class BookServices : IServices
    {
        IBookRepository bookRepository;

        public BookServices(IBookRepository iBookRepository)
        {
            bookRepository = iBookRepository;
        }

        public void add(Book book)
        {
            bookRepository.add(book);
        }

        public void delete(Book book)
        {
            bookRepository.delete(book);
        }

        public Book get(int id)
        {
            return bookRepository.get(id);
        }

        public List<Book> getAll()
        {
            return bookRepository.getAll();
        }
    }
}
