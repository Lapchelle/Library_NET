using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Library.Data
{
    public class PostgresContext : IdentityDbContext<User>
    {
        public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        
       

        public virtual DbSet<Borrow> Borrows { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

       



       

}
}
