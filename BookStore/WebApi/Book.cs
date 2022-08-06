using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApi

{
    public class Book
    {

        [DatabaseGenerated(DataBaseGenerationOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

}