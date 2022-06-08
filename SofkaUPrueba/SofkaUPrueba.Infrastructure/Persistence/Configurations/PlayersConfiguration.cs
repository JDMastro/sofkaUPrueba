using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Infrastructure.Persistence.Configurations
{
    public class PlayersConfiguration : IEntityTypeConfiguration<Players>
    {
        public void Configure(EntityTypeBuilder<Players> builder)
        {
            builder.HasIndex(t => t.Username).IsUnique().HasDatabaseName("Idx_username_players");
        }
    }
}
