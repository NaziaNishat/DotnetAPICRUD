using DataAccess;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IServices<T> where T : class
    {
        IEnumerable<T> getAll();
        void add(T entity);
        T get(int id);
        void delete(int id);
        void update(T entity,int id);
    }
}
