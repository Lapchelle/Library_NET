using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        
        public bool IsAdmin { get; set; }
       

        public string Email { get; set; }

        
        public ICollection<Borrow> Borrows { get; set; }

        
    }
}
