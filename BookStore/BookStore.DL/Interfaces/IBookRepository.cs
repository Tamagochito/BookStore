using BookStore.Models.DTO;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book?> GetById(string id);

        Task Add(Book book);

        Task Update(Book book);
    }
}
