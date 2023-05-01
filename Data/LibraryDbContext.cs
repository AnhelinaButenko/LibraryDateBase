using Data.Configuration;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class LibraryDbContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Author> Author { get; set; }
    public DbSet<AuthorBook> AuthorBook { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<BookLibrary> BookLibrary { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Library> Library { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<StudentBook> StudentBook { get; set; }

    public LibraryDbContext(string connectionString = "Data Source=DESKTOP-DLBKOUP\\SQLEXPRESS; Initial Catalog =libraryContext; Integrated Security = True; TrustServerCertificate=True")
    {
        _connectionString = connectionString;
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorBookConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new BookLibraryConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyConfiguration());
        modelBuilder.ApplyConfiguration(new LibraryConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherConfiguration());
        modelBuilder.ApplyConfiguration(new StudentBookConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());

        modelBuilder.Entity<Book>().HasData(
           new Book[]
           {
                new Book { Id=1, Name="Day", DateOfPublication= new DateTime(2000, 11, 27), NumberOfPages=99, NumberOfIllustation=19},
                new Book { Id=2, Name="Way", DateOfPublication= new DateTime(1975, 2, 25), NumberOfPages=123, NumberOfIllustation=32},
           });

        modelBuilder.Entity<Author>().HasData(
            new Author[]
            {
                new Author { Id=1, FullName="Sagh Ghiny Deryo", CreatedDate=new DateTime(1560, 11, 14), ModifiedDate= DateTime.UtcNow},
                new Author { Id=2, FullName="Duipky Dyrew Fewsi", CreatedDate=new DateTime(1896, 11, 19) ,ModifiedDate= DateTime.UtcNow},
            });

        modelBuilder.Entity<Library>().HasData(
            new Library[]
            {
                new Library { Id=1, Name="Lonf"},
                new Library { Id=2, Name="Dewsi"},
            });

        modelBuilder.Entity<Publisher>().HasData(
           new Publisher[]
           {
                new Publisher { Id=1, Name="Daverim"},
                new Publisher { Id=2, Name="Fokpit"},
           });

        modelBuilder.Entity<Faculty>().HasData(
          new Faculty[]
          {
                new Faculty { Id=1, Name="History"},
                new Faculty { Id=2, Name="Geography"},
          });

        modelBuilder.Entity<Student>().HasData(
          new Student[]
          {
                new Student { Id=1, Name="Ivan", FacultyId=1},
                new Student { Id=2, Name="Stepan", FacultyId=1},
          });

        modelBuilder.Entity<AuthorBook>().HasData(
          new AuthorBook[]
          {
                new AuthorBook { Id=1, BookId=1, AuthorId=1, PublisherId=1},
                new AuthorBook { Id=2, BookId=2, AuthorId=2, PublisherId=2},
          });

        modelBuilder.Entity<BookLibrary>().HasData(
         new BookLibrary[]
         {
                new BookLibrary { Id=1, BookId=1, LibraryId=1, CountBook=4},
                new BookLibrary { Id=2, BookId=2, LibraryId=2, CountBook=9},
         });

        modelBuilder.Entity<StudentBook>().HasData(
         new StudentBook[]
         {
                new StudentBook { Id=1, BookId=1, StudentId=1 ,StartOfTake= new DateTime(2022, 1, 11), EndOfTake= new DateTime(2022, 2, 22)},
                new StudentBook { Id=2, BookId=2, StudentId=2, StartOfTake= new DateTime(2021, 2, 14), EndOfTake= new DateTime(2022, 3, 11)},
         });
    }
}
