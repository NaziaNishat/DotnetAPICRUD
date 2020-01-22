using DataAccess;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IServices
    {
        List<Book> getAll();
        void add(Book book);
        Book get(int id);
        void delete(Book book);
    }
}
