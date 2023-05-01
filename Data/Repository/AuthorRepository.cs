using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author> Update(int id, Author author);

    Task<Author> GetById(int id);

    Task Add(Author author);

    Task Remove(Author author);

    Task<List<Author>> GetAll();
}

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }
    
    public override async Task<Author> Update(int id, Author author)
    {
        Author entityForUpdate = await LibraryDbContext.Set<Author>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return author;
        }

        entityForUpdate.FullName = author.FullName;
        return await base.Update(id, author);
    }
}

