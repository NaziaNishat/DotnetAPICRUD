using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Valuescontroller : ControllerBase
    {
        public IServices<Book> services ;


        public Valuescontroller(IServices<Book> iservices)
        {
            services = iservices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(services.getAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return services.get(id);

        }

        // POST api/values
        [HttpPost]
        public object Post([FromBody] Book book)
        {
            services.add(book);
            return book;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            Book getBook = services.get(id);
            getBook.title = book.title;
            getBook.author = book.author;
            services.update(getBook,id);
            return Ok(services.getAll());

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            services.delete(id);
            return Ok(services.getAll());
        }
    }
}
