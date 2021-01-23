namespace DayHelper.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskDeleteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Finished = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateToFinish = c.DateTime(nullable: false),
                        TaskList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskList_Id)
                .Index(t => t.TaskList_Id);
            
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Finished = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Difficulty = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateToFinish = c.DateTime(nullable: false),
                        TaskList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskList_Id)
                .Index(t => t.TaskList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskList_Id", "dbo.TaskLists");
            DropForeignKey("dbo.TaskDeleteds", "TaskList_Id", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "TaskList_Id" });
            DropIndex("dbo.TaskDeleteds", new[] { "TaskList_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskLists");
            DropTable("dbo.TaskDeleteds");
        }
    }
}
