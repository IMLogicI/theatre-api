namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbBook
    { 
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual DbAccount Account { get; set; }

        public int ScheduleId { get; set; }
        public virtual DbSchedule Schedule { get; set; }
    }
}