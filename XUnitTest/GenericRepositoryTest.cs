using BookApi.Controllers;
using DataAccess;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class GenericRepositoryTest
    {
        private GenericRepository genericRepository;
        private IBookstoreDatabaseSettings settings;
        //private Mock<IServices<Book>> services;
        private Mock<Book> book;
        //private readonly IMongoDatabase database;
        private MockGenericRepository mockGenericRepository;

        List<Book> booklist = new List<Book>();
        public readonly IGenericRepository MockRepo;



        public GenericRepositoryTest()
        {

            booklist.Add(new Book { id = 1, title = "nishat1", author = "author1" });
            booklist.Add(new Book { id = 2, title = "nishat2", author = "author2" });
            booklist.Add(new Book { id = 3, title = "nishat3", author = "author3" });

            settings = new BookstoreDatabaseSettings();
            settings.ConnectionString = "mongodb://localhost:27017";
            settings.DatabaseName = "StudentDB";
            genericRepository = new GenericRepository(settings);
            //services = new Mock<IServices<Book>>();
            book = new Mock<Book>();

            Mock<IGenericRepository> mockRepo = new Mock<IGenericRepository>();


            mockRepo.Setup(e => e.get<Book>(It.IsAny<int>())).Returns(
                (int id) =>
                {
                    var bookObj = booklist.FirstOrDefault(e => e.id == id);
                    return bookObj;
                });

            mockRepo.Setup(e => e.add<Book>(It.IsAny<Book>())).Returns(
            (Book book) =>
            {
                return book;
            });

            mockRepo.Setup(e => e.delete<Book>(It.IsAny<int>())).Returns(
            (int id )=>
            {
                var bookObj = booklist.FirstOrDefault(e => e.id == id);
                booklist.RemoveAt(id - 1);

                return null;
            });

            mockRepo.Setup(e => e.update<Book>(It.IsAny<Book>(), It.IsAny<int>())).Returns(
            (Book book,int id) =>
            {
                var bookObj = booklist.FirstOrDefault(e => e.id == id);
                bookObj = book;
                return bookObj;
            });

            mockRepo.Setup(e => e.getAll<Book>()).Returns(
            booklist);



            this.MockRepo = mockRepo.Object;

            //var client = new MongoClient("mongodb://localhost:27017");
            //database = client.GetDatabase("StudentDB");
            //collection = database.GetCollection<Book>(typeof(Book).Name + "Info");


        }


        [Fact]
        public void Add_Valid_Data_Returns_OK()
        {
            var actualResult = this.MockRepo.add<Book>(new Book { id = 12, title = "nishat12", author = "author12" });
            //var actualResult = genericRepository.add<Mock<Book>>(book);
            var jsonActualResult = actualResult.ToJson();
            var expectedResult = new Book { id = 12, title = "nishat12", author = "author12" };
            var jsonExpectedResult = actualResult.ToJson();

            Assert.Equal(jsonExpectedResult, jsonActualResult);
        }

        [Fact]
        public void Get_Valid_Data_Returns_OK()
        {
            int id = 1;
            //var actualResult = genericRepository.get<Book>(id);


            var actualResult = this.MockRepo.get<Book>(1);
            var jsonActualResult = actualResult.ToJson();
            var expectedResult = new Book{id= 1,title= "nishat1", author= "author1"};
            var jsonExpectedResult = actualResult.ToJson();

            Assert.Equal(jsonExpectedResult , jsonActualResult);
        }

        [Fact]
        public void Get_For_InValid_Data_Returns_OK()
        {
            int id = 100;
            var actualResult = genericRepository.get<Book>(id);
            var jsonActualResult = actualResult.ToJson();
            //var result = null;
            //var jsonResult = result.ToJson();

            Assert.Null(jsonActualResult);
        }

        [Fact]
        public void Update_Valid_Data_Returns_OK()
        {
            int id = 2;
            var book = this.MockRepo.get<Book>(id);
            book.title = "nishatUpdated";
            var actualResult = this.MockRepo.update<Book>(book, id);
            var jsonActualResult = actualResult.ToJson();
            var result = new Book { id = 2, title = "nishatUpdated", author = "author2" };
            var jsonResult = actualResult.ToJson();
            Assert.Equal(jsonResult, jsonActualResult);
        }

        [Fact]
        public void Delete_Valid_Data_Returns_OK()
        {
            int id = 3;
            var result = this.MockRepo.delete<Book>(id);
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_Valid_Data_Returns_OK()
        {
            var result = this.MockRepo.getAll<Book>();
            Assert.Equal(booklist,result);
        }

    }


}
