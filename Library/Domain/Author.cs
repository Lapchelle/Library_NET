using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        ICollection<Book> Books { get; set; }
    }
}
