namespace DayHelper.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
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
            
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskList_Id", "dbo.TaskLists");
            DropForeignKey("dbo.TaskLists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tags", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskLists", new[] { "User_Id" });
            DropIndex("dbo.Tasks", new[] { "TaskList_Id" });
            DropIndex("dbo.Tags", new[] { "Task_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.TaskLists");
            DropTable("dbo.Tasks");
            DropTable("dbo.Tags");
        }
    }
}
