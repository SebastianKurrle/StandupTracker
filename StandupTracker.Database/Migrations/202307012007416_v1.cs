namespace StandupTracker.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayNotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreaterId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreaterId, cascadeDelete: true)
                .Index(t => t.CreaterId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayNotes", "CreaterId", "dbo.Users");
            DropIndex("dbo.DayNotes", new[] { "CreaterId" });
            DropTable("dbo.Users");
            DropTable("dbo.DayNotes");
        }
    }
}
