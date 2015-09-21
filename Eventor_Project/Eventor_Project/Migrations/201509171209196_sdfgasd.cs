namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfgasd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        OrganizationDate = c.DateTime(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectNews",
                c => new
                    {
                        ProjectNewsId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ProjectNewsId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectComments",
                c => new
                    {
                        ProjectCommentId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ProjectCommentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "Project_ProjectId", c => c.Int());
            AddForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects", "ProjectId");
            CreateIndex("dbo.Users", "Project_ProjectId");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            DropIndex("dbo.ProjectComments", new[] { "UserId" });
            DropIndex("dbo.ProjectComments", new[] { "ProjectId" });
            DropIndex("dbo.ProjectNews", new[] { "ProjectId" });
            DropIndex("dbo.Users", new[] { "Project_ProjectId" });
            DropForeignKey("dbo.ProjectComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProjectComments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectNews", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropColumn("dbo.Users", "Project_ProjectId");
            DropTable("dbo.ProjectComments");
            DropTable("dbo.ProjectNews");
            DropTable("dbo.Projects");
        }
    }
}
