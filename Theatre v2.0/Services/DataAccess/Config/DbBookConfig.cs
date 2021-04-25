using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbBookConfig : EntityTypeConfiguration<DbBook>
    {
        public DbBookConfig()
        {
            HasKey(a => a.Id);

            HasRequired(a => a.Account)
                .WithMany(b => b.Books)
                .HasForeignKey(c => c.UserId);

            HasRequired(a => a.Schedule)
                .WithMany(b => b.Books)
                .HasForeignKey(c => c.ScheduleId);
        }
    }
}