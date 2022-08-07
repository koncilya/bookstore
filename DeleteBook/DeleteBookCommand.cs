using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBooksCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }

        public DeleteBooksCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);
            if (book is null)
            throw new InvalidOperationException("silinicek kıtap yok");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        

           
        }
    }
}