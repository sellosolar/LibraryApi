#nullable disable

namespace Library.Core.Entities
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public int IdEditorial { get; set; }
        public int IdAuthor { get; set; }

        public virtual Author Author { get; set; }
        public virtual Editorial Editorial { get; set; }
    }
}
