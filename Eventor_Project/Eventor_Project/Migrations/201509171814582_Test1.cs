namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Organizers", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            AddColumn("dbo.Projects", "Headquarter", c => c.String());
            AddColumn("dbo.Projects", "Place", c => c.String());
            AlterColumn("dbo.Organizers", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.UserMaterials", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Organizers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            CreateIndex("dbo.UserMaterials", "UserId");
            CreateIndex("dbo.Organizers", "UserId");
            DropTable("dbo.Blogs");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            DropIndex("dbo.Organizers", new[] { "UserId" });
            DropIndex("dbo.UserMaterials", new[] { "UserId" });
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMaterials", "UserId", "dbo.Users");
            AlterColumn("dbo.Organizers", "UserId", c => c.Int());
            DropColumn("dbo.Projects", "Place");
            DropColumn("dbo.Projects", "Headquarter");
            CreateIndex("dbo.Posts", "BlogId");
            CreateIndex("dbo.Organizers", "UserId");
            AddForeignKey("dbo.Posts", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.Organizers", "UserId", "dbo.Users", "UserId");
        }
    }
}
