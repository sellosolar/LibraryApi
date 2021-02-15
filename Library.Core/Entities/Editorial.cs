using System.Collections.Generic;

#nullable disable

namespace Library.Core.Entities
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int MaxBooksToRegister { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
