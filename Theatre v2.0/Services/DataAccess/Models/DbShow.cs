using System.Collections.Generic;

namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbShow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Length { get; set; }

        public int JenreId { get; set; }
        public virtual DbJenre Jenre { get; set; }

        public virtual ICollection<DbShowActors> ShowActors { get; set; } 

        public virtual ICollection<DbSchedule> Schedules { get; set; }
    }
}