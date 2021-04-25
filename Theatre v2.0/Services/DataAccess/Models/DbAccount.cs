using System.Collections.Generic;

namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbAccount
    {
        public int Id { get; set; } 

        public string Email { get; set; }
        
        public string Password { get; set; }

        public virtual ICollection<DbBook> Books { get; set; }
    }
}