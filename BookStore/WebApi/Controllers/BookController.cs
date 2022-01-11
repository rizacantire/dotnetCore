using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.BookOperations.GetBooks;
namespace WebApi.Controllers

{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return result(result);
        }

        [HttpGet("{id}")]
        public Book GetBooks(int id)
        {
            var book = _context.Books.Where(book=>book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book GetBooks([FromQuery] string id)
        // {
        //     var book = BookList.Where(book=>book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Title == newBook.Title);
            if(book is not null) 
                return BadRequest();
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updateBook)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            
             _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
        
    }
}