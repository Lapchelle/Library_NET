using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Review
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public User User { get; set; }
        [ForeignKey("Book")]

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
