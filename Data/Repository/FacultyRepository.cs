using Domains;

namespace Data.Repository;

public interface IFacultyRepository : IGenericRepository<Faculty>
{
    Task<Faculty> Update(int id, Faculty faculty);

    Task<Faculty> GetById(int id);

    Task Add(Faculty faculty);

    Task Remove(Faculty faculty);

    Task<List<Faculty>> GetAll();
}

public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }

    public override async Task<Faculty> Update(int  id, Faculty newFaculty)
    {
        using var libraryDbContext = new LibraryDbContext();

        Faculty entityForUpdate = libraryDbContext.Faculties.Single(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return newFaculty;
        }

        entityForUpdate.Name = newFaculty.Name;

        return await base.Update(id, newFaculty);
    }
}
