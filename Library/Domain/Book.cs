using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
        public virtual ICollection<Book_Genre> Book_Genres { get; set; }



        public string? PublishDate { get; set; }

        public string? PublishHouse { get; set; }

        public int? PageCount { get; set; }

        

        public bool? IsPublic { get; set; }


        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
