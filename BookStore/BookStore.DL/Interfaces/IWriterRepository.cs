using BookStore.Models.DTO;

namespace BookStore.DL.Interfaces
{
    public interface IWriterRepository
    {
        Task<List<Writer>> GetAll();

        Task<List<Writer>> GetAll(List<string> ids);

        Task<Writer?> GetById(string id);

        Task Add(Writer? writer);

        void Update(Writer writer);
    }
}
