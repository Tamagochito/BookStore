using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using BookStore.BL.Interfaces;
using BookStore.Models.DTO;
using BookStore.Models.Requests;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;
        private readonly IMapper _mapper;

        public BooksController(
            IBooksService bookService,
            IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest($"Wrong ID:{id}");
            }

            var result = _bookService.GetById(id);

            if (result == null)
            {
                return NotFound($"Book with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]AddBookRequest book)
        {
            if (book == null)
            {
                return BadRequest("Book is null");
            }

            var bookDto = _mapper.Map<Book>(book);

            await _bookService.Add(bookDto);

            return Ok();
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            //return _bookService.GetById(id);
        }
    }
}
