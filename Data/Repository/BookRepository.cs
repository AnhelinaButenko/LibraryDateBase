using Domains;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book> Update(int id, Book book);

    Task<Book> GetById(int id);

    Task Add(Book book);

    Task Remove(Book book);

    Task<List<Book>> GetAll();
}

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
    {
    }

    public override async Task<Book> Update(int id, Book book)
    {
        Book entityForUpdate = await LibraryDbContext.Set<Book>().SingleAsync(x => x.Id == id);

        if (entityForUpdate == null)
        {
            return book;
        }

        entityForUpdate.Name = book.Name;
        entityForUpdate.DateOfPublication = book.DateOfPublication;
        entityForUpdate.NumberOfPages = book.NumberOfPages;
        entityForUpdate.NumberOfIllustation = book.NumberOfIllustation;

        return await base.Update(id, entityForUpdate);
    }
}
