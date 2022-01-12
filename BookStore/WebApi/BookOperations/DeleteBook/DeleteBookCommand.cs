using WebApi.Common;
using WebApi.Entities;
using WebApi.DbOperations;
using System.Linq;
using System.Collections.Generic;
using System;

namespace WebApi.BookOperations.DeleteBookCommand
{
    public class DeleteBookCommand
    {

        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int bookId)
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Id == bookId);
            if(book is null)
                throw new InvalidOperationException("Kitap sistemde mevcut değil.");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        
    } 
}