using BookStore.Models.DTO;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
      {
        List<Book> GetAll();

        Book? GetById(string id);

        Task Add(Book book);

        void AddWriterToBook(string bookId, string writer);
    }
}
