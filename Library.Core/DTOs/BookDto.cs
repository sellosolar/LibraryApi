namespace Library.Core.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }
        public string AuthorName { get; set; }
        public string EditorialName { get; set; }
    }
}
