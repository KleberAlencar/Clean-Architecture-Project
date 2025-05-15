using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Shared.Entities;
using CleanArc.Domain.Accounts.Entities;

namespace CleanArc.Infrastructure.Shared.Data;

public class AppDbContext(IPublisher publisher, DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await publisher.Publish(this, cancellationToken);
        return result;
    }

    private async Task PublishDomainEvents()
    {
        var events = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents;
                return domainEvents;
            }).ToList();
        
        foreach (var domainEvent in events)
            await publisher.Publish(domainEvent);

        foreach (var entity in ChangeTracker
                     .Entries<Entity>()
                     .Select(entry => entry.Entity))
        {
            entity.ClearDomainEvents();
        }
    }
}