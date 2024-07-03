namespace Library.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Book_Genre> Book_Genres { get; set; }

    }
}
