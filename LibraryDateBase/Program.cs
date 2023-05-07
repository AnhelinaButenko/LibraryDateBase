using Data;
using Data.Repository;
using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LibraryDateBase;

public class Program
{
    public static async Task Main(string[] args)
    {
        AuthorRepository authorRepository = new AuthorRepository(new LibraryDbContext());

        await authorRepository.Add(new Author { FullName = "Asdfg Teru Pomft", CreatedDate = new DateTime(1999, 01, 13), ModifiedDate = DateTime.UtcNow });
        await authorRepository.Remove(new Author { Id = 6, ModifiedDate = DateTime.UtcNow });
        await authorRepository.Update(1, new Author { FullName = "Boytr Mhiny Oeryo" });
        Author authorGetById = await authorRepository.GetById(6);

        List<Author> authors = await authorRepository.GetAll();
        foreach (Author author in authors)
        {
            Console.WriteLine(
                $"Автор:{author.FullName}" +
                $"CreatedDate:{author.CreatedDate}" +
                $"CreatedDate:{author.ModifiedDate}.");
        };


    }
}



/* 1) для указанного филиала посчитать количество экземпляров указанной книги, находящихся в нем;
var numOfBooksInLibrary = await db.BookLibrary
   .AsNoTracking()
   .Include(s => s.Library)
   .Include(s => s.Book)
   .Where(s => s.LibraryId == 1 && s.BookId == 1)
   .Select(s => new
   {
       s.LibraryId,
       s.CountBook,
   }).FirstOrDefaultAsync();

Console.WriteLine($"{numOfBooksInLibrary.LibraryId} : {numOfBooksInLibrary.CountBook}");


 2) для указанной книги посчитать количество факультетов,на которых она используется в данном филиале,и вывести названия этих факультетов;
var numOfFaculty = await db.StudentBook
   .AsNoTracking()
   .Include(s => s.Student.Faculty)
   .Include(s => s.Book)
   .Where(s => s.BookId == 2)
   .Select(s => new
   {
       s.Student.Faculty.Name,
       s.Student.Faculty.Name.Count()
   }).ToList();

foreach (var item in numOfFaculty)
{
   Console.WriteLine($"{item.Student.Faculty.Name} : {item.Student.Faculty.Name.Count()}");
}

 3) предоставить возможность добавления и изменения  информации о книгах в библиотеке;

 4) предоставить возможность добавления и изменения информации о филиалах;

var editingInformationLibraries = await db.Library
   .AsNoTracking()
   .Select(s => new
   {
       s.Id,
       s.Name,
   }).ToList();

foreach (var item in editingInformationLibraries)
{
   Console.WriteLine($"{item.Id} : {item.Name}");
}




        //using (LibraryDbContext db = new LibraryDbContext("Data Source=DESKTOP-DLBKOUP\\SQLEXPRESS; Initial Catalog =libraryContext; Integrated Security = True; TrustServerCertificate=True"))
        //{
        //    var book = new Book();
        //    book.Name = "TestBook";
        //    book.DateOfPublication = DateTime.Now;
        //    book.NumberOfIllustation= 34;
        //    book.NumberOfPages = 211;
        //    book.CreatedDate = DateTime.Now;

        //    db.Book.Add(book);

        //    await db.SaveChangesAsync();

        //    // bookrepo
        //    // Add
        //    // Update
        //    // Remove
        //    // GetById
            
        //}

*/