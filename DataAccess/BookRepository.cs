using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;



namespace DataAccess
{
    public class BookRepository<T> : IBookRepository<T> where T : class
    {
        public List<Book> bookList = new List<Book>();

        private readonly IMongoCollection<T> collection;
        private readonly IMongoDatabase database;
        String tablename;


        public BookRepository(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
            tablename = typeof(T).Name;


            collection = database.GetCollection<T>(tablename + "Info");
        }

        public void add(T entity)
        {
            //entity.id = bookList.Max(e => e.id) + 1;
            collection.InsertOne(entity);
            //bookList.Add(book);
        }

        public void delete(int id)
        {
            //bookList.Remove(book);
            var deleteFilter = Builders<T>.Filter.Eq("id", id);
            collection.DeleteOne(deleteFilter);
        }

        public T get(int id)
        {
            //return bookList.FirstOrDefault(e => e.id == id);
            var readFilter = Builders<T>.Filter.Eq("id", id);
            var studentDocument = collection.Find(readFilter).FirstOrDefault();

            return studentDocument;

        }

        public IEnumerable<T> getAll()
        {

            var documents = collection.Find(new BsonDocument());
            return documents.ToEnumerable();
        }

        public void update(T entity, int id)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            collection.ReplaceOne(filter, entity);
        }
    }

}
