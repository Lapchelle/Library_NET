﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class Router
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Street { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }

        public string? ContactNumber { get; set; }  

        public ICollection<Borrow> Borrows { get; set; }
    }
}
