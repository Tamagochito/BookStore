using Microsoft.AspNetCore.Mvc;
using BookStore.BL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBookBlService _bookService;
        private readonly IWriterService _writerService;

        public BusinessController(IBookBlService bookService, IWriterService writerService)
        {
            _bookService = bookService;
            _writerService = writerService;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllBookWithDetails")]
        public IActionResult GetAllBookWithDetails()
        {
            var result = _bookService.GetDetailedBooks();

            if (result == null || result.Count == 0)
            {
                return NotFound("No books found");
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddWriter")]
        public IActionResult AddWriter([FromBody] Writer writer)
        {
            _writerService.Add(writer);

            return Ok();
        }

    }
}
