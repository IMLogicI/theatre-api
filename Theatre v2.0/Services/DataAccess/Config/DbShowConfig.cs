using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbShowConfig : EntityTypeConfiguration<DbShow>
    {
        public DbShowConfig()
        {
            HasKey(a => a.Id);

            HasRequired(a => a.Jenre)
                .WithMany(b => b.Shows)
                .HasForeignKey(c => c.JenreId);

            HasMany(a => a.Schedules)
                .WithRequired(b => b.Show)
                .HasForeignKey(b => b.ShowId);

            HasMany(a => a.ShowActors)
                .WithRequired(b => b.Show)
                .HasForeignKey(b => b.ShowId);
        }
    }
}