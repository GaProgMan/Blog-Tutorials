using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webApiTutorial.Services;

namespace webApiTutorial.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IBookService _bookService;

        public ValuesController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            if (_bookService != null)
            {
                return new string[] { "Book service is ready" };
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
