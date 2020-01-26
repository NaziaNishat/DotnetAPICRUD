using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBookRepository<T> where T : class
    {
        IEnumerable<T> getAll();
        void add(T entity);
        T get(int id);
        void delete(int id);
        void update(T entity, int id);



    }
}
