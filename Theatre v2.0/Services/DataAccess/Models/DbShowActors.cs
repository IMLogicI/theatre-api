namespace Theatre_v2._0.Services.DataAccess.Models
{
    public class DbShowActors
    {
        public int Id { get; set; }

        public int ShowId { get; set; }
        public virtual DbShow Show { get; set; }

        public int ActorId { get; set; }
        public virtual DbActor Actor { get; set; }

        public string Role { get; set; }
    }
}