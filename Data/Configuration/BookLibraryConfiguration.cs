using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class BookLibraryConfiguration : IEntityTypeConfiguration<BookLibrary>
{
    public void Configure(EntityTypeBuilder<BookLibrary> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CountBook);

        builder.HasOne(e => e.Book).WithMany(e => e.BookLibraries).HasForeignKey(e => e.BookId);

        builder.HasOne(e => e.Library).WithMany(e => e.BookLibraries).HasForeignKey(e => e.LibraryId);
    }
}
