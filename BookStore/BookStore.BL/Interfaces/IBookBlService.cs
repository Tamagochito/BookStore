﻿using BookStore.Models.Views;

namespace BookStore.BL.Interfaces
{
    public interface IBookBlService
     {
        Task<List<BookFullDetailsResponse>> GetAllBooks();
    }
}
