using Moq;
using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookService.Tests
{
    public class BookBlServiceTests
    {
        private Mock<IBookService> _bookServiceMock;
        private Mock<IWriterRepository> _writerRepositoryMock;

        public BookBlServiceTests()
        {
            _bookServiceMock = new Mock<IBookService>();
            _writerRepositoryMock = new Mock<IWriterRepository>();
        }

        private List<Book> _books = new List<Book>
        {
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 1",
                Year = 2021,
                Writers = ["Writer 1", "Writer 2"]
            },
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Movie 2",
                Year = 2022,
                Writers = ["Writer 3", "Writer 4"]
            }
        }; 

        private List<Writer> _writers = new List<Writer>
        {
            new Writer()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Writer 1"
            },
            new Writer()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Writer 2"
            },
            new Writer()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Writer 3"
            },
            new Writer()
            {
                Id = "9badefdc-0714-4581-80ae-161cd0a5abbe",
                Name = "Writer 4"
            }
        };

        [Fact]
        public void GetDetailedBooks_Ok()
        {
            //setup
            var expectedCount = 2;

            _bookServiceMock
                .Setup(x => x.GetAllBooks())
                .Returns(_books);
            _writerRepositoryMock.Setup(x => 
                    x.GetById(It.IsAny<string>()))
                .Returns((string id) =>
                    _writers.FirstOrDefault(x => x.Id == id));

            //inject
            var bookBlService = new BookBlService(
                _bookServiceMock.Object,
                _writerRepositoryMock.Object);

            //Act
            var result =
                bookBlService.GetDetailedBooks();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }

    }
}
