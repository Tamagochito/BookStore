using BookStore.DL.StaticDB;
using BookStore.Models.DTO;

namespace BookStore.DL.Repositories
{
    //[Obsolete]
    //internal class BookStaticRepository 
    //{
    //    public List<Book> GetAllBooks()
    //    {
    //        return InMemoryDb.Books;
    //    }

    //    public void AddBook(Book book)
    //    {
    //        if (book == null) return;

    //        book.Id = Guid.NewGuid().ToString();
    //        InMemoryDb.Books.Add(book);
    //    }

    //    /// <summary>
    //    /// Get book by id
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <returns></returns>
    //    public Book? GetBookById(string id)
    //    {
    //       return InMemoryDb.Books
    //           .FirstOrDefault(b => b.Id == id);
    //    }
    //}
}
