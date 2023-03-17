namespace Domains;

public class BookLibrary : BaseEntity
{
    public int CountBook { get; set; }

    public int LibraryId { get; set; }

    public Library Library { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }
}
