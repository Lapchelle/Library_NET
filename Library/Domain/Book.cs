using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        public string? Title { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public Genre Genre { get; set; }

        public string? BookImageURL { get; set; }

        public string? PublishDate { get; set; }

        public string? PublishHouse { get; set; }

        public int? PageCount { get; set; }

        

        public Boolean? IsPublic { get; set; }


        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
