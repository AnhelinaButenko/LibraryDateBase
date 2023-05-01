using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IGenericRepository<T>
    where T : class
{
    Task<T> Update(int id, T entity);

    Task<T> GetById(int id);

    Task Add(T entity);

    Task Remove(T entity);

    Task<List<T>> GetAll();
}

public abstract class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    protected readonly LibraryDbContext LibraryDbContext;

    public GenericRepository(LibraryDbContext libraryDbContext)
    {
        LibraryDbContext = libraryDbContext;
    }

    public virtual async Task Add(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;

        LibraryDbContext.Set<T>().Add(entity);
        await LibraryDbContext.SaveChangesAsync();
    }

    public async Task Remove(T entity)
    {
        LibraryDbContext.Set<T>().Remove(entity);
        await LibraryDbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await LibraryDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> Update(int id, T entity)
    {
        T entityForUpdate = await LibraryDbContext.Set<T>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return entity;
        }

        entityForUpdate.ModifiedDate = DateTime.UtcNow;

        LibraryDbContext.Set<T>().Update(entity);
        await LibraryDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> GetById(int id)
    {
        return await LibraryDbContext.Set<T>().FindAsync(id);
    }
}


