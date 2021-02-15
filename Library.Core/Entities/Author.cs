using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Core.Entities
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Library.Core.Entities.Book>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProcedenceCity { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
