using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library.Infrastructure.Data
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedenceCity)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Author");

                entity.HasOne(d => d.Editorial)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Editorial");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.ToTable("Editorial");

                entity.Property(e => e.Id);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });
        }
    }
}
