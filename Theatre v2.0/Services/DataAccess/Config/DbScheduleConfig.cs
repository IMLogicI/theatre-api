using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbScheduleConfig : EntityTypeConfiguration<DbSchedule>
    {
        public DbScheduleConfig()
        {
            HasKey(a => a.Id);

            HasRequired(a => a.Show)
                .WithMany(b => b.Schedules)
                .HasForeignKey(c => c.ShowId);

            HasMany(a => a.Books)
                .WithRequired(b => b.Schedule)
                .HasForeignKey(b => b.ScheduleId);
        }
    }
}