namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Author_UserId", c => c.Int());
            AddForeignKey("dbo.Projects", "Author_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            CreateIndex("dbo.Projects", "Author_UserId");
            CreateIndex("dbo.Projects", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropIndex("dbo.Projects", new[] { "Author_UserId" });
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Projects", "Author_UserId", "dbo.Users");
            DropColumn("dbo.Projects", "Author_UserId");
            DropColumn("dbo.Projects", "CategoryId");
            DropColumn("dbo.Projects", "AuthorId");
        }
    }
}
