using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
{
    public void Configure(EntityTypeBuilder<AuthorBook> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Author).WithMany(e => e.AuthorBooks).HasForeignKey(e => e.AuthorId);

        builder.HasOne(e => e.Book).WithMany(e => e.AuthorBooks).HasForeignKey(e => e.BookId);

        builder.HasOne(e => e.Publisher).WithMany(e => e.AuthorBooks).HasForeignKey(e => e.PublisherId);
    }
}
