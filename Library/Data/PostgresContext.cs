using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Library.Domain;


namespace Library.Data
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }

    }
}
