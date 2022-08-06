using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace WebApi.AddControllers
{   
    [ApiController]
    [Route("[controllers]s")]

    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
                new Book{
                    Id = 1,
                    Title="leen start",
                    GenreId = 1, //personal 
                    PageCount = 200,
                    PublishDate = new DateTime(2000,06,12)
                },
                new Book{
                    Id = 2,
                    Title="herland",
                    GenreId = 2, //secience
                    PageCount = 250,
                    PublishDate = new DateTime(2010,05,12)
                },
                new Book{
                    Id = 3,
                    Title="dune",
                    GenreId = 1, //personal 
                    PageCount = 300,
                    PublishDate = new DateTime(2020,06,12)
                }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return BookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book=> book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpGet]
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(book=> book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }

        //post

        [HttpPost]

        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x=> x.Title == newBook.Title);

            if (book is not null)
                return BadRequest();

            BookList.Add(newBook);
            return Ok();
        }

        //put

        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x=>x.Id == id);
            if(book is null)
                return BadRequest();

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            return Ok();
        }    

        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x=> x.Id == id);
            if (book is null)
                return BadRequest();

                BookList.Remove(book);
                return Ok();


        }
    }
}