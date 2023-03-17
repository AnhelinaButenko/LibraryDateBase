namespace Domains;

public class AuthorBook : BaseEntity
{
    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }

    public int PublisherId { get; set; }

    public Publisher Publisher { get; set; }
}
