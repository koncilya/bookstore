using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{

    public class UpdateBookCommand
    {
            private readonly BookStoreDbContext _context;

            public int BookId { get; set; }

            public UpdateBookModel Model { get; set; }

            public UpdateBookCommand(BookStoreContext context)
            {
                _context = context;
            }

            public void Handle()
            {

             var book = _context.Books.SingleOrDefault(x=>x.Id == BookId);
            if(book is null)
                throw new InvalidOperationsException("güüncel kitap yok");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _context.SaveChanges();
            }

            public class UpdateBookModel
            {
                public string Title { get; set; }

                public int Gnere { get; set; }
            }
    }    
}