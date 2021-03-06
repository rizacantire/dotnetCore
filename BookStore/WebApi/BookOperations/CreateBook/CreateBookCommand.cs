using WebApi.Common;
using WebApi.Entities;
using WebApi.DbOperations;
using System.Linq;
using System.Collections.Generic;
using System;

namespace WebApi.BookOperations.CreateBookCommand
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}

        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
             var book = _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);
            if(book is not null) 
                throw new InvalidOperationException("Kitap sistemde mevcut");
            book = new Book();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        
    } 
    public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
}