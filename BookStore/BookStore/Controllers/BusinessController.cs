using Microsoft.AspNetCore.Mvc;
using BookStore.BL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _bookService;

        public BusinessController(IBusinessService bookService)

        {
            _bookService = bookService;
        }

        [HttpGet("GetAllDetailedBooks")]
        public IActionResult GetAllDetailedBooks()
        {
            var result =
                _bookService.GetAllBooks();

            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }

            return NotFound();
        }

    }
}
