using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories.MongoRepositories
{
    internal class WriterRepository : IWriterRepository
    {
        private readonly IMongoCollection<Writer> _writersCollection;
        private readonly ILogger<WriterRepository> _logger;

        public WriterRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<WriterRepository> logger)
        {
            _logger = logger;

            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _writersCollection = database.GetCollection<writer>("WritersDb");
        }

        public async Task<List<Writer>> GetAll()
        {
            var result = await _writersCollection.FindAsync(m => true);

            return await result.ToListAsync();
        }

        public async Task<Writr?> GetById(string id)
        {
            var result = await _writersCollection
                .FindAsync(m => m.Id == id);

             return result.FirstOrDefault();
        }

        public async Task Add(Writer? writer)
        {
            if (writer == null)
            {
                _logger.LogError("Book is null");

                return;
            }

            try
            {
                await _writersCollection.InsertOneAsync(writer);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add book");
            }
        }

        public void Update(Writer book)
        {
            _writersCollection.ReplaceOne(m => m.Id == book.Id, book);
        }

        public async Task<List<Writer>> GetAll(List<string> ids)
        {
            if (ids == null || !ids.Any()) return [];

            var result = await _writersCollection.FindAsync(m => ids.Contains(m.Id));

            return await result.ToListAsync();
        }
    }
}
