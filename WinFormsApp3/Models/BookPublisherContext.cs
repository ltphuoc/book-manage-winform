using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WinFormsApp3.Models
{
    public partial class BookPublisherContext : DbContext
    {
        public BookPublisherContext()
        {
        }

        public BookPublisherContext(DbContextOptions<BookPublisherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountUser> AccountUsers { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BookPublisher;uid=sa;pwd=1234567890;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AccountU__1788CCACE5DC1361");

                entity.ToTable("AccountUser");

                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserFullName).HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(90);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId)
                    .HasMaxLength(20)
                    .HasColumnName("BookID");

                entity.Property(e => e.AuthorName).HasMaxLength(150);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PublisherId)
                    .HasMaxLength(20)
                    .HasColumnName("PublisherID");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Book__PublisherI__286302EC");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.PublisherId)
                    .HasMaxLength(20)
                    .HasColumnName("PublisherID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PublisherName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
