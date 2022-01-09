using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers

{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{

        private static List<Book> BookList = new List<Book>()
        {
            new Book{Id = 1, Title = "Lean Startup",GenreId = 1,
            PageCount = 200,
            PublishDate = new DateTime(2001,06,12)
            },
            new Book{Id = 2, Title = "Herland",GenreId = 2,
            PageCount = 250,
            PublishDate = new DateTime(2010,05,23)
            },
            new Book{Id = 3, Title = "Dune",GenreId = 2,
            PageCount = 540,
            PublishDate = new DateTime(2002,12,21)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x=>x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetBooks(int id)
        {
            var book = BookList.Where(book=>book.Id == id).SingleOrDefault();
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
            var book = BookList.SingleOrDefault(x=>x.Title == newBook.Title);
            if(book is not null) 
                return BadRequest();
            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updateBook)
        {
            var book = BookList.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();
            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();
            BookList.Remove(book);
            return Ok();
        }
        
    }
}