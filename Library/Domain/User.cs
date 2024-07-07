using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    
    public class User : IdentityUser
    {
        
        

        
        public string? FullName { get; set; }

        public string? Description { get; set; }


        public string? Address { get; set; }

        //public ICollection<Borrow> Borrows { get; set; }


    }
}
