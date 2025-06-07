using Castle.Core.Logging;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.DTO;

namespace BookStore.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Mock<IWriterRepository> _writerRepositoryMock;

        private List<Writer> _writers = new List<Writer>
        {
            new Writer()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Writer 1"
            },
            new Actor()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Writer 2"
            },
            new Actor()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Writer 3"
            },
        };

        private List<Book> _books = new List<Book>()
        {
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 1",
                Year = 2021,
                Writer = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Book()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Book 2",
                Year = 2022,
                Writer = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _writerRepositoryMock = new Mock<IWriterRepository>();
        }

        [Fact]
        void GetById_Ok()
        {
            //Arrange
            var bookId = _books[0].Id;

            _bookRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _books.FirstOrDefault(m => m.Id == id));

            //var logger = Mock.Of<ILogger<BooksService>>();
            var loggerMock = new Mock<ILogger<BooksService>>();
            ILogger<BooksService> logger = loggerMock.Object;

            //Act
            var bookService = new BooksService(
                _bookRepositoryMock.Object,
                logger,
                _writerRepositoryMock.Object);

            var result = bookService.GetById(bookId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(bookId, result.Id);
        }

        [Fact]
        void GetById_NotExistingId()
        {
            //Arrange
            var bookId = Guid.NewGuid().ToString();

            _bookRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _books.FirstOrDefault(m => m.Id == id));

            var loggerMock = new Mock<ILogger<BooksService>>();
            ILogger<BooksService> logger = loggerMock.Object;

            //Act
            var bookService = new BooksService(
                _bookRepositoryMock.Object,
                logger,
                _writerRepositoryMock.Object);

            var result = bookService.GetById(bookId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        void GetById_WrongGuidId()
        {
            //Arrange
            var bookId = "F";

            _bookRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _books.FirstOrDefault(m => m.Id == id));

            //var logger = Mock.Of<ILogger<BooksService>>();
            var loggerMock = new Mock<ILogger<BooksService>>();
            ILogger<BookService> logger = loggerMock.Object;

            //Act
            var bookService = new BookService(
                _bookRepositoryMock.Object,
                logger,
                _writerRepositoryMock.Object);

            var result = bookService.GetById(bookId);

            //Assert
            Assert.Null(result);
        }
    }
}
}
        }

    }
}
