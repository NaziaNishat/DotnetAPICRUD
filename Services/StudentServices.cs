using DataAccess;
using System;
using System.Collections.Generic;

namespace Services
{
    public class StudentServices : IServices
    {
        IRepository repository;

        public StudentServices(IRepository irepository)
        {
            repository = irepository;
        }

        public void add(Book book)
        {
            repository.add(book);
        }

        public void delete(Book book)
        {
            repository.delete(book);
        }

        public Book get(int id)
        {
            return repository.get(id);
        }

        public List<Book> getAll()
        {
            return repository.getAll();
        }
    }
}
