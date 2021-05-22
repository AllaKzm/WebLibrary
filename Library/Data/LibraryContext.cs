using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Library.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Library.Data
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

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<IssuedBook> IssuedBooks { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Reader> Reader { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\1\\Desktop\\ИСП-21\\proectdb\\Library\\Library.db");
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Database=Library.db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.BookTitle)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.GenId)
                    .HasColumnName("GenID")
                    .HasColumnType("INT");

                entity.Property(e => e.PubId)
                    .HasColumnName("PubID")
                    .HasColumnType("INT");

                entity.Property(e => e.PubYear)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Gen)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnName("passportData")
                    .HasColumnType("NVARCHAR(10)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(11)");

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("INT");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenId);

                entity.Property(e => e.GenId)
                    .HasColumnName("GenID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.GenTitle)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");
            });

            modelBuilder.Entity<IssuedBook>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("INT");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasColumnType("INT");

                entity.Property(e => e.IssueDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.ReadId)
                    .HasColumnName("ReadID")
                    .HasColumnType("INT");

                entity.Property(e => e.ReturnDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.ReturnMark)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Read)
                    .WithMany()
                    .HasForeignKey(d => d.ReadId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.Property(e => e.PositionId)
                    .HasColumnName("PositionID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Demands)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.Duties)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.PositionTitle)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.Salary).HasColumnType("FLOAT");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId);

                entity.Property(e => e.PubId)
                    .HasColumnName("PubID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.PublicistTitle)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.HasKey(e => e.ReadId);

                entity.Property(e => e.ReadId)
                    .HasColumnName("ReadID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.BirthDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(MAX)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
