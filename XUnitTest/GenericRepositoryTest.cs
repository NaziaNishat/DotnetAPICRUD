using BookApi.Controllers;
using DataAccess;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class GenericRepositoryTest
    {
        private GenericRepository genericRepository;
        private IMongoCollection<Book> collection;
        private IBookstoreDatabaseSettings settings;
        private readonly Valuescontroller valuesController;
        private Mock<IServices<Book>> services;
        //private Mock<Book> book;
        private readonly IMongoDatabase database;


        public GenericRepositoryTest()
        {
            settings = new BookstoreDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDB";
            genericRepository = new GenericRepository(settings);
            services = new Mock<IServices<Book>>();
            valuesController = new Valuescontroller(services.Object);
            //book = new Mock<Book>();

            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("StudentDB");
            collection = database.GetCollection<Book>(typeof(Book).Name + "Info");


        }

        //[Fact]
        //public async void Add_Valid_Data_Returns_OK()
        //{
        //    collection.InsertOne(new Book { id = 100, title = "aryan", author = "Mr. Aryan" });
        //}

        [Fact]
        public void Add_Valid_Data_Returns_OK()
        {
            var actualResult = genericRepository.add<Book>(new Book { id = 10, title = "nishat10", author = "author10" });
            var jsonActualResult = actualResult.ToJson();
            var expectedResult = new Book { id = 10, title = "nishat10", author = "author10" };
            var jsonExpectedResult = actualResult.ToJson();

            Assert.Equal(jsonExpectedResult, jsonActualResult);
        }

        [Fact]
        public void Get_Valid_Data_Returns_OK()
        {
            int id = 1;
            var actualResult = genericRepository.get<Book>(id);
            var jsonActualResult = actualResult.ToJson();
            var expectedResult = new Book   {id= 1,title= "nishatUpdated", author= "authorNN"};
            var jsonExpectedResult = actualResult.ToJson();

            Assert.Equal(jsonExpectedResult , jsonActualResult);
        }

        //[Fact]
        //public void Get_For_InValid_Data_Returns_OK()
        //{
        //    int id = 100;
        //    var actualResult = genericRepository.get<Book>(id);
        //    var jsonActualResult = actualResult.ToJson();
        //    //var result = null;
        //    //var jsonResult = result.ToJson();

        //    Assert.Equal(, jsonActualResult);
        //}

        [Fact]
        public void Update_Valid_Data_Returns_OK()
        {
            int id = 2;
            var book = genericRepository.get<Book>(id);
            book.title = "nishatUpdated";
            var actualResult = genericRepository.update<Book>(book, id);
            var jsonActualResult = actualResult.ToJson();
            var result = new Book { id = 2, title = "nishatUpdated", author = "author2" };
            var jsonResult = actualResult.ToJson();
            Assert.Equal(jsonResult, jsonActualResult);
        }

        [Fact]
        public void Delete_Valid_Data_Returns_OK()
        {
            int id = 3;
           // var book = genericRepository.delete<Book>(id);
            var result = genericRepository.delete<Book>(id);
            var jsonResult = result.ToJson();
            var actualResult = new Book { id = 3, title = "nishat2", author = "author3" };
            var jsonActualResult = actualResult.ToJson();
            Assert.Equal(jsonResult, jsonActualResult);
        }

    }


}
