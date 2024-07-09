using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    
    public class User : IdentityUser
    {
       
      


        public string? FirstName { get; set; }

        public string? LastName { get; set; }


        public string? Address { get; set; }

        public string? Phone_number { get; set; }

        //public ICollection<Borrow> Borrows { get; set; }


    }
}
