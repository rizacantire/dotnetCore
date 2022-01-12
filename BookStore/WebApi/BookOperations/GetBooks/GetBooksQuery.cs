using WebApi.Common;
using WebApi.Entities;
using WebApi.DbOperations;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel(){
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),            
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
                });
            }
            return vm;
        }

        public BookViewModel HandleById(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            BookViewModel bvm = new BookViewModel(){
                Title=book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),            
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy")
                };
            return bvm;
        }
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}