using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<Student> Update(int id, Student student);

    Task<Student> GetById(int id);

    Task Add(Student student);

    Task Remove(Student student);

    Task<List<Student>> GetAll();
}

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }

    public override async Task<Student> Update(int id, Student student)
    {
        Student entityForUpdate = await LibraryDbContext.Set<Student>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return student;
        }

        entityForUpdate.Name = student.Name;
        return await base.Update(id, student);
    }
}
