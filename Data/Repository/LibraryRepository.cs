using Domains;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Data.Repository;

public interface ILibraryRepository : IGenericRepository<Library>
{
    Task<Library> Update(int id, Library library);

    Task<Library> GetById(int id);

    Task Add(Library library);

    Task Remove(Library library);

    Task<List<Library>> GetAll();
}

public class LibraryRepository : GenericRepository<Library>, ILibraryRepository
{
    public LibraryRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }

    public override async Task<Library> Update(int id, Library library)
    {
        Library entityForUpdate = await LibraryDbContext.Set<Library>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return library;
        }

        entityForUpdate.Name = library.Name;

        return await base.Update(id, library);
    }
}
