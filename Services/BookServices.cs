using DataAccess;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Services
{
    public class BookServices<T> : IServices<T> where T : class
    {
        IBookRepository<T> bookRepository;

        //IMongoCollection<T> collection;
        //IMongoDatabase database;
        ////MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
        //String tablename = typeof(T).Name;

        //public BookServices()
        //{
        //    database = dbClient.GetDatabase("StudentDB");

        //}

        public BookServices(IBookRepository<T> ibookrepository)
        {
            bookRepository = ibookrepository;
        }

        public void add(T entity)
        {
            //collection = database.GetCollection<T>(tablename + "Info");
            //collection.InsertOne(entity);
            bookRepository.add(entity);
        }

        public void delete(int id)
        {
            bookRepository.delete(id);
            //collection = database.GetCollection<T>(tablename + "Info");

            //var deleteFilter = Builders<T>.Filter.Eq("id", id);
            //collection.DeleteOne(deleteFilter);
        }

        public T get(int id)
        {
            //collection = database.GetCollection<T>(tablename + "Info");

            //var readFilter = Builders<T>.Filter.Eq("id", id);
            //var studentDocument = collection.Find(readFilter).FirstOrDefault();

            //return studentDocument;
            return bookRepository.get(id);
        }

        public IEnumerable<T> getAll()
        {
            //collection = database.GetCollection<T>(tablename + "Info");

            //var documents = collection.Find(new BsonDocument());
            //return documents.ToEnumerable();
            return bookRepository.getAll();
        }

        public void update(T entity,int id)
        {
            bookRepository.update(entity,id);
            //collection = database.GetCollection<T>(tablename + "Info");

            //var filter = Builders<T>.Filter.Eq("id", id);
            //collection.ReplaceOne(filter, entity);
        }
    }
}
