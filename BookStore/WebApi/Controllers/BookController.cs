using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using HelloWebApi.BookOperations.CreateBook;
using HelloWebApi.BookOperations.GetBooks;
using HelloWebApi.DbOperations;
using Microsoft.AspNetCore.Mvc;
using static HelloWebApi.BookOperations.CreateBook.CreateBooksCommand;



namespace WebApi.AddControllers
{   
    [ApiController]
    [Route("[controllers]s")]

    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

    public BookController (BookStoreDbContext context)
    {
        _context = context;
    }

        // private static List<Book> BookList = new List<Book>()
        // {
        //         new Book{
        //             Id = 1,
        //             Title="leen start",
        //             GenreId = 1, //personal 
        //             PageCount = 200,
        //             PublishDate = new DateTime(2000,06,12)
        //         },
        //         new Book{
        //             Id = 2,
        //             Title="herland",
        //             GenreId = 2, //secience
        //             PageCount = 250,
        //             PublishDate = new DateTime(2010,05,12)
        //         },
        //         new Book{
        //             Id = 3,
        //             Title="dune",
        //             GenreId = 1, //personal 
        //             PageCount = 300,
        //             PublishDate = new DateTime(2020,06,12)
        //         }
        // };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book=> book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        //post

        [HttpPost]

        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        //put

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            _context.SaveChanges();


            return Ok();
        }    

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == id);
            if (book is null)
                return BadRequest();

                _context.Books.Remove(book);
                _context.SaveChanges();
                
                return Ok();


        }
    }
}