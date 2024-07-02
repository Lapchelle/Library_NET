using System.ComponentModel.DataAnnotations;

namespace Library.Domain
{
    public class Librarian
    {
        
        public int id { get; set; }
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        ICollection<Book> Books {  get; set; }

        ICollection<User> Users { get; set; }   


    }
}
