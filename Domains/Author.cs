namespace Domains;

public class Author : BaseEntity
{
    public string FullName { get; set; }

    public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
}
