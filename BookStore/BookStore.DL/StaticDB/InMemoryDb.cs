using BookStore.Models.DTO;

namespace BookStore.DL.StaticDB
{
    internal static class InMemoryDb
    {
        internal static List<Writer> Writers
            = new List<Writer>
        {
            new Writer
            {
                Id = "1",
                Name = "Hristo Botev"
            },
            new Actor
            {
                Id = "2",
                Name = "Mihail Georgiev"
            },
            new Actor
            {
                Id = "3",
                Name = "Nikola Vapcarov"
            },
            new Actor
            {
                Id = "4",
                Name = "Atanas Dalchev"
            },
            new Actor
            {
                Id = "5",
                Name = "Elin Pelin"
            },
            new Actor
            {
                Id = "6",
                Name = "Dimitar Talev"
            },
        };

        //internal static List<Book> Books = new List<Book>
        //{
        //    new Book
        //    {
        //        Id = "1",
        //        Title = "Literatura za 5. klas",
        //        Year = 2013,
        //        Writers = new List<int>
        //        {
        //            1, 2
        //        }
        //    },
        //    new Book
        //    {
        //        Id = "2",
        //        Title = "Literatura 11. klas",
        //        Year = 2006,
        //        Writers = new List<int>
        //        {
        //            3, 4
        //        }
        //    },
        //    new Book
        //    {
        //        Id = "3",
        //        Title = "Literatura 12. klas",
        //        Year = 2009,
        //        Writers = new List<int>
        //        {
        //            5, 6
        //    }
        //},
        //};
    }
}
