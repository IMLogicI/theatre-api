using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbActorConfig : EntityTypeConfiguration<DbActor>
    {
        public DbActorConfig()
        {
            HasKey(a => a.Id);

            HasMany(a => a.ShowActors)
                .WithRequired(b => b.Actor)
                .HasForeignKey(b => b.ActorId);
        }
    }
}