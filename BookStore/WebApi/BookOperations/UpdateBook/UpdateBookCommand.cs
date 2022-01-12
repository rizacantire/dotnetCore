using WebApi.Common;
using WebApi.Entities;
using WebApi.DbOperations;
using System.Linq;
using System.Collections.Generic;
using System;

namespace WebApi.BookOperations.UpdateBookCommand
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get; set;}

        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int bookId)
        {
             var book = _dbContext.Books.SingleOrDefault(x=>x.Id == bookId);
            if(book is null)
                throw new InvalidOperationException("Kitap sistemde mevcut değil.");
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            
             _dbContext.SaveChanges();
        }

        
    } 
    public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
}