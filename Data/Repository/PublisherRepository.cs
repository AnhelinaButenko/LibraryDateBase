using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IPublisherRepository : IGenericRepository<Publisher>
{
    Task<Publisher> Update(int id, Publisher publisher);

    Task<Publisher> GetById(int id);

    Task Add(Publisher publisher);

    Task Remove(Publisher publisher);

    Task<List<Publisher>> GetAll();
}

public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }

    public override async Task<Publisher> Update(int id, Publisher publisher)
    {
        Publisher entityForUpdate = await LibraryDbContext.Set<Publisher>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return publisher;
        }

        entityForUpdate.Name = publisher.Name;
        return await base.Update(id, publisher);
    }
}
