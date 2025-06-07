using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories.MongoRepositories
{
    internal class BookStaticDataRepository : IBookRepository
    {
        //public List<Book> GetAll()
        //{
        //    return StaticDb.Books;
        //}

        //public Book? GetById(string id)
        //{
        //    if (string.IsNullOrEmpty(id)) return null;

        //    return StaticDb.Books
        //        .FirstOrDefault(x => x.Id == id);
        //}
        public Task Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll()
        {
            return StaticDb.Books;
        }

        public Task<Book?> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }
    }


}
                .FirstOrDefault();
        }
    }
}
