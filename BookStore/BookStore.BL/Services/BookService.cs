using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IWriterRepository writerRepository)
        {
            _bookRepository = bookRepository;
            _writerRepository = writerRepository;
        }
        
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public void AddBook(Book? book)
        {
            if (book is null ) return;

            foreach (var bookWriter in book.Writer)
            {
                var writer = _writerRepository.GetById(bookWriter);

                if (writer is null)
                {
                    throw new Exception(
                        $"Writer with id {bookWriter} does not exist");
                }
            }

            _bookRepository.AddBook(book);
        }

        public Book? GetById(string id)
        {
            return _bookRepository.GetMovieById(id);
        }
    }
}
