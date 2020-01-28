using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository
    {
        IEnumerable<T> getAll<T>();
        T add<T>(T entity);
        T get<T>(int id);
        T delete<T>(int id);
        T update<T>(T entity, int id);



    }
}
