using System.Collections.Generic;

namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbActor
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        
        public string LastName { get; set; }

        public int Age { get; set; }

        public int Gender { get; set; }

        public virtual ICollection<DbShowActors> ShowActors { get; set; }
    }
}