using System;
using System.Collections.Generic;

namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbSchedule
    {
        public int Id { get; set; }

        public int ShowId { get; set; }
        public virtual DbShow Show { get; set; }

        public DateTime Date { get; set; }

        public int FreePlaces { get; set; }

        public virtual ICollection<DbBook> Books { get; set; }
    }
}