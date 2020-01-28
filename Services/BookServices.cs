using DataAccess;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Services
{
    public class BookServices<T> : IServices<T> where T : Book
    {
        IGenericRepository genericRepository;

        public BookServices(IGenericRepository igenericrepository)
        {
            genericRepository = igenericrepository;
        }

        public void add(T entity)
        {
            genericRepository.add<T>(entity);
        }

        public void delete(int id)
        {
            genericRepository.delete<T>(id);

        }

        public T get(int id)
        {
            return genericRepository.get<T>(id);
        }

        public IEnumerable<T> getAll()
        {

            return genericRepository.getAll<T>();
        }

        public void update(T entity,int id)
        {
            genericRepository.update(entity,id);

        }
    }
}
