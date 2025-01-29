using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;
using BookStore.Models.Views;

namespace MovieStore.BL.Services
{
    internal class BookBlService : IBookBlService
    {
        private readonly IBookService _bookService;
        private readonly IWriterRepository _writerRepository;

        public BookBlService(
            IBookService bookService,
            IWriterRepository writerRepository)
        {
            _bookService = bookService;
            _writerRepository = writerRepository;
        }

        public List<BookView> GetDetailedBooks()
        {
            var result = new List<BookView>();

            var books = _bookService.GetAllBooks();

            foreach (var book in books)
            {
                var bookView = new BookView
                {
                    BookId = book.Id,
                    BookTitle = book.Title,
                    BookYear = book.Year,
                    Writers = _writerRepository.GetWritersByIds(book.Writers)
                };

                result.Add(bookView);
            }

            return result;
        }
    }
}
