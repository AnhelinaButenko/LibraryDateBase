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

    //public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    //{
    //}

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

        //modelBuilder.Entity<Client>().HasData(
        //   new Client[]
        //   {
        //        new Client { ClientId=1, FirstName="Ivan", LastName="Ivanov", Firm="Samsung", DateOfBirth= new DateTime(2000, 12, 27)},
        //        new Client { ClientId=2, FirstName="Alice", LastName="Petrova", Firm="Lenovo", DateOfBirth=new DateTime(1975, 03, 15)},
        //   });

        //modelBuilder.Entity<Project>().HasData(
        //   new Project[]
        //   {
        //        new Project { ProjectId=1, ClientId=1, Name = "Creation of new models of gadgets", Budget = 56.500M, StartedDate = new DateTime(2023,02,16)},
        //        new Project { ProjectId=2, ClientId=2, Name = "Creation of new system for work", Budget = 87.500M, StartedDate = new DateTime(2023,02,16)},
        //   });
    }
}
