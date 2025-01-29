using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.BL.Services
{
    internal class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        public WriterService(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public void Add(Writer writer)
        {
            _actorRepository.AddWriter(writer);
        }
    }
}
