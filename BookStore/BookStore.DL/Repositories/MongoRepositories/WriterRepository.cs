using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories.MongoRepositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly IMongoCollection<Writer> _writers;
        private readonly ILogger<WriterRepository> _logger;

        public ActorRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<WriterRepository> logger)
        {
            _logger = logger;
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);

            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);

            _writers = database.GetCollection<Writer>(
                $"{nameof(Writer)}s");
        }

        public void AddWriter(Writer writer)
        {
            writer.Id = System.Guid.NewGuid().ToString();
            _writers.InsertOne(writer);
        }

        public void AddBook(Writer book)
        {
            if (book == null)
            {
                _logger.LogError("Book is null");
                return;
            }

            try
            {
                movie.Id = Guid.NewGuid().ToString();

                _actors.InsertOne(book);
            }
            catch (Exception e)
            {
               _logger.LogError(e,
                   $"Error adding book {e.Message}-{e.StackTrace}");
            }
           
        }


        public IEnumerable<Writer> GetActorsByIds(IEnumerable<string> writersIds)
        {
            var result = _writers.Find(writer => writersIds.Contains(writer.Id)).ToList();
            return result;
        }

        public Writer? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return _writers.Find(b => b.Id == id)
                .FirstOrDefault();
        }
    }
}
