using BookStore.Models.DTO;

namespace BookStore.DL.Interfaces
{
    public interface IWriterRepository
    {
        void AddWriter(Writer writer);
        IEnumerable<Writer> GetWritersByIds(IEnumerable<string> writersIds);
        Writer? GetById(string id);
    }
}
