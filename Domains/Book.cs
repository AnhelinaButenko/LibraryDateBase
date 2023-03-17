namespace Domains;

public class Book : BaseEntity
{
    public string Name { get; set; }

    public DateTime DateOfPublication { get; set; }

    public int NumberOfPages { get; set; }

    public int NumberOfIllustation { get; set; }

    public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();

    public List<BookLibrary> BookLibraries { get; set; } = new List<BookLibrary>();

    public List<StudentBook> StudentBooks { get; set; } = new List<StudentBook>();
}
