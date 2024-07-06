using Library.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Dto
{
    public class BookDto    
    {

        public int Id { get; set; }
        public string? Title { get; set; }

        public int? AuthorId { get; set; }
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string? PublishDate { get; set; }

        public string? PublishHouse { get; set; }

        public int? PageCount { get; set; }

        public bool? IsPublic { get; set; }
    }
}
