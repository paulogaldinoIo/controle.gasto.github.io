using Domain.Core.Events;
using Infra.Data.Mappings.StoriesEvents;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contexts
{
    public class EventStoreSQLContext : DbContext
    {

        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options) { }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
