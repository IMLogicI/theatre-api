using System.Collections.Generic;

namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbJenre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<DbShow> Shows { get; set; }
    }
}