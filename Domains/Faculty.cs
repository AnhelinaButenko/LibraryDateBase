namespace Domains;

public class Faculty : BaseEntity
{
    public string Name { get; set; }

    public List<Student> Students { get; set; } = new List<Student>();
}
