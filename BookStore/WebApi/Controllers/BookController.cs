using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBookCommand;
using WebApi.BookOperations.UpdateBookCommand;
using WebApi.BookOperations.DeleteBookCommand;

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
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooks(int id)
        {
             GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.HandleById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
           try
           {
            command.Model = newBook;
            command.Handle();
           }
           catch (Exception e)
           {
               
               return BadRequest(e.Message);
           }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
           UpdateBookCommand command = new UpdateBookCommand(_context);
           try
           {
            command.Model = updateBook;
            command.Handle(id);
           }
           catch (Exception e)
           {
               
               return BadRequest(e.Message);
           }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
             DeleteBookCommand command = new DeleteBookCommand(_context);
           try
           {
            command.Handle(id);
           }
           catch (Exception e)
           {
               return BadRequest(e.Message);
           }
           return Ok();
        }
        
    }
}