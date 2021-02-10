namespace Theatre_v2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbAccount");
        }
    }
}
