namespace Theatre_v2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTheatreTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAccount", t => t.Account_Id)
                .ForeignKey("dbo.DbSchedule", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.DbSchedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FreePlaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbShow", t => t.ShowId, cascadeDelete: true)
                .Index(t => t.ShowId);
            
            CreateTable(
                "dbo.DbShow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Length = c.Int(nullable: false),
                        JenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbJenre", t => t.JenreId, cascadeDelete: true)
                .Index(t => t.JenreId);
            
            CreateTable(
                "dbo.DbJenre",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbShowActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbActor", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.DbShow", t => t.ShowId, cascadeDelete: true)
                .Index(t => t.ShowId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.DbActor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbShowActors", "ShowId", "dbo.DbShow");
            DropForeignKey("dbo.DbShowActors", "ActorId", "dbo.DbActor");
            DropForeignKey("dbo.DbSchedule", "ShowId", "dbo.DbShow");
            DropForeignKey("dbo.DbShow", "JenreId", "dbo.DbJenre");
            DropForeignKey("dbo.DbBook", "ScheduleId", "dbo.DbSchedule");
            DropForeignKey("dbo.DbBook", "Account_Id", "dbo.DbAccount");
            DropIndex("dbo.DbShowActors", new[] { "ActorId" });
            DropIndex("dbo.DbShowActors", new[] { "ShowId" });
            DropIndex("dbo.DbShow", new[] { "JenreId" });
            DropIndex("dbo.DbSchedule", new[] { "ShowId" });
            DropIndex("dbo.DbBook", new[] { "Account_Id" });
            DropIndex("dbo.DbBook", new[] { "ScheduleId" });
            DropTable("dbo.DbActor");
            DropTable("dbo.DbShowActors");
            DropTable("dbo.DbJenre");
            DropTable("dbo.DbShow");
            DropTable("dbo.DbSchedule");
            DropTable("dbo.DbBook");
        }
    }
}
