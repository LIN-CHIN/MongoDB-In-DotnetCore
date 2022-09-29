using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB_In_DotnetCoreAPI.Model;
using MongoDB_In_DotnetCoreAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_In_DotnetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IList<Book>> Get()
        {
           return _service.Get();
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] string id, [FromBody] Book book )
        {
            _service.Update(id, book);
            return Ok("success");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] string id)
        {
            _service.Delete(id);
            return Ok("success");
        }

    }
}
