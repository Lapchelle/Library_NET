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
        public virtual DbSet<BookCopy> BookCopies { get; set; }

        public virtual DbSet<Borrow> Borrows { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Router> Routers { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book_Genre> Book_Genres { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Genre>()
                .HasKey(pc => new { pc.BookId, pc.GenreId });
            modelBuilder.Entity<Book_Genre>()
                    .HasOne(p => p.Book)
                    .WithMany(pc => pc.Book_Genres)
                    .HasForeignKey(p => p.BookId);
            modelBuilder.Entity<Book_Genre>()
                    .HasOne(p => p.Genre)
                    .WithMany(pc => pc.Book_Genres)
                    .HasForeignKey(c => c.GenreId);
        }

}
}
