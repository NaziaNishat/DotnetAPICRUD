using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository
    {
        List<Book> getAll();
        void add(Book book);
        Book get(int id);
        void delete(Book book);

    }
}
