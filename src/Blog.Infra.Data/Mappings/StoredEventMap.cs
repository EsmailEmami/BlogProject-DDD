using Blog.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infra.Data.Mappings;

public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
{
    public void Configure(EntityTypeBuilder<StoredEvent> builder)
    {
        builder.Property(c => c.Timestamp)
            .HasColumnName("CreationDate");

        builder.Property(c => c.MessageType)
            .HasColumnName("Action")
            .HasColumnType("nvarchar(100)");
    }
}