namespace Domains;

public class Student : BaseEntity
{
    public string Name { get; set; }

    public int FacultyId { get; set; }

    public Faculty Faculty { get; set; }

    public List<StudentBook> StudentBooks { get; set; } = new List<StudentBook>();
}
