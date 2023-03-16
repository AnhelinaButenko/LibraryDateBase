namespace Domains;

public class Book : BaseEntity
{
    public string Name { get; set; }

    public DateTime DateOfPublication { get; set; }

    public int NumberOfPages { get; set; }

    public int NumberOfIllustation { get; set; }
}
