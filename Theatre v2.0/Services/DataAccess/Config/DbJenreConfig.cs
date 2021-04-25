using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbJenreConfig : EntityTypeConfiguration<DbJenre>
    {
        public DbJenreConfig()
        {
            HasKey(a => a.Id);

            HasMany(a => a.Shows)
                .WithRequired(b => b.Jenre)
                .HasForeignKey(b => b.JenreId);
        }
    }
}