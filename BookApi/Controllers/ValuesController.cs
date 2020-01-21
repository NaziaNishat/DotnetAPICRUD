using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IRepository repository;


        public ValuesController(IRepository irepository)
        {
            repository = irepository;
        }
/*
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            //return new string[] { "value1", "value2" };
            return repository.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return repository.get(id);
        }

        // POST api/values
        [HttpPost]
        public object Post([FromBody] Book book)
        {
            repository.add(book);
            return book;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            Book getBook = repository.get(id);
            getBook.title = book.title;
            getBook.author = book.author;
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book getBook = repository.get(id);
            repository.delete(getBook);
            return Ok();
        }
    }
}
