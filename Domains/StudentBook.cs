namespace Domains;

public class StudentBook : BaseEntity
{
    public DateTime StartOfTake { get; set; }

    public DateTime EndOfTake { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }

    public int BookId { get; set; }

    public Book Book { get; set; }
}
