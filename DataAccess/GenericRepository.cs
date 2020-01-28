using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;



namespace DataAccess
{
    public class GenericRepository : IGenericRepository
    {

        //private IMongoCollection collection;
        private readonly IMongoDatabase database;

        public GenericRepository(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);

            //collection = database.GetCollection<T>(typeof(T).Name + "s");
        }

        public T add<T>(T entity)
        {
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name + "Info");
            collection.InsertOne(entity);
            return entity;
        }

        public T delete<T>(int id)
        {
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name + "Info");
            var deleteFilter = Builders<T>.Filter.Eq("id", id);
            var deletedBook = collection.Find(deleteFilter).FirstOrDefault();

            collection.DeleteOne(deleteFilter);
            return deletedBook;

        }

        public T get<T>(int id)
        {
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name + "Info");
            var readFilter = Builders<T>.Filter.Eq("id", id);
            var book = collection.Find(readFilter).FirstOrDefault();

            return book;

        }

        public IEnumerable<T> getAll<T>()
        {
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name + "Info");
            var documents = collection.Find(new BsonDocument());
            return documents.ToEnumerable();
        }

        public T update<T>(T entity, int id)
        {
            IMongoCollection<T> collection = database.GetCollection<T>(typeof(T).Name + "Info");
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.ReplaceOne(filter, entity);
            return entity;
        }
    }

}
