namespace WebApi.DBOperations
{
    public class BookStoreDbContext : BookStoreDbContext
    {
        public BookStoreDbContext(DbContextOperations<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}