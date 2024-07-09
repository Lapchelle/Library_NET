using Library.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BookDto    
    {

      
        public int Id { get; set; }
        public string? Title { get; set; }

        public int? AuthorId { get; set; }
      


     
        public int? GenreId { get; set; }

       

        public string? ImageUrl { get; set; }

        public string? PublishDate { get; set; }

        public string? PublishHouse { get; set; }

        public int? PageCount { get; set; }




      

        public string? Condition { get; set; }

    
    }
}
