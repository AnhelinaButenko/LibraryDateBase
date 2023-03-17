using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(50);

        builder.Property(e => e.DateOfPublication).HasColumnType("date");

        builder.Property(e => e.NumberOfPages);

        builder.Property(e => e.NumberOfIllustation);
    }
}
