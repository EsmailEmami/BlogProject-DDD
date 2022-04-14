﻿using Blog.Domain.Core.Events;
using Blog.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Data.Context;

public class EventStoreSqlContext : DbContext
{
    public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options)
    {
    }

    public DbSet<StoredEvent> StoredEvent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StoredEventMap());

        base.OnModelCreating(modelBuilder);
    }
}