namespace Domains;

public class Library : BaseEntity
{
    public string Name { get; set; }

    public List<BookLibrary> BookLibraries { get; set; } = new List<BookLibrary>();
}
