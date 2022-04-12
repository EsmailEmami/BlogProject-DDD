using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Data.Mappings;

public class BlogMap:IEntityTypeConfiguration<Domain.Models.Blog>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Blog> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("BlogId");

        builder.Property(c => c.BlogTitle)
            .HasColumnType("nvarchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}