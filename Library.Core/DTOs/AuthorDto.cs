using System;

namespace Library.Core.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProcedenceCity { get; set; }
        public string Email { get; set; }
    }
}
