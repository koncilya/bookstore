namespace WebApi.DBOperations
{

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOption<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRangee(
                new Book{
                    // Id = 1,
                    Title="leen start",
                    GenreId = 1, //personal 
                    PageCount = 200,
                    PublishDate = new DateTime(2000,06,12)
                },
                new Book{
                    // Id = 2,
                    Title="herland",
                    GenreId = 2, //secience
                    PageCount = 250,
                    PublishDate = new DateTime(2010,05,12)
                },
                new Book{
                    // Id = 3,
                    Title="dune",
                    GenreId = 1, //personal 
                    PageCount = 300,
                    PublishDate = new DateTime(2020,06,12)
                    
                }
                );

                context.SaveChanges();

                
            }
        }
    }
}