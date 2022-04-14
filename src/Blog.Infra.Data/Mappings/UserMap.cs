using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("UserId");

        builder.Property(c => c.FirstName)
            .HasColumnType("nvarchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasColumnType("nvarchar(50)")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}