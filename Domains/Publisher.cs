namespace Domains;

public class Publisher : BaseEntity
{
    public string Name { get; set; }

    public List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
}

