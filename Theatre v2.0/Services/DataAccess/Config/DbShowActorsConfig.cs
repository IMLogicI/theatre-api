using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbShowActorsConfig : EntityTypeConfiguration<DbShowActors>
    {
        public DbShowActorsConfig()
        {
            HasKey(a => a.Id);

            HasRequired(a => a.Show)
                .WithMany(b => b.ShowActors)
                .HasForeignKey(c => c.ShowId);

            HasRequired(a => a.Actor)
                .WithMany(b => b.ShowActors)
                .HasForeignKey(c => c.ActorId);
        }
    }
}