using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class StudentBookConfiguration : IEntityTypeConfiguration<StudentBook>
{
    public void Configure(EntityTypeBuilder<StudentBook> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.StartOfTake).HasColumnType("date");

        builder.Property(e => e.EndOfTake).HasColumnType("date");

        builder.HasOne(e => e.Book).WithMany(e => e.StudentBooks).HasForeignKey(e => e.BookId);

        builder.HasOne(e => e.Student).WithMany(e => e.StudentBooks).HasForeignKey(e => e.StudentId);
    }
}
