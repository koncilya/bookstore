using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBooksCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbContext;
        public CreateBooksCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
                throw new InvalidOperationException("Kitap var"); //uyarı mesajı yazdırmak için
            
                book = new Book();
                book.Title = Model.Title;
                book.PageCount = Model.PageCount;
                book.PublishDate = Model.PublishDate;
                book.GenreId = Model.GenreId;

                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
        
    }
}
