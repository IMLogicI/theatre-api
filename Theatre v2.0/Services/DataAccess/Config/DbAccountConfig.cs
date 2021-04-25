using System.Data.Entity.ModelConfiguration;
using Theatre_v2._0.Services.DataAccess.Models;

namespace Theatre_v2._0.Services.DataAccess.Config
{
    public class DbAccountConfig : EntityTypeConfiguration<DbAccount>
    {
        public DbAccountConfig()
        {
            HasKey(a => a.Id);

            HasMany(a => a.Books)
                .WithRequired(b => b.Account)
                .HasForeignKey(b => b.UserId);
        }
    }
}