namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_categotyid_projectmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            AlterColumn("dbo.Projects", "CategoryId", c => c.Int());
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "CategoryId");
            CreateIndex("dbo.Projects", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            AlterColumn("dbo.Projects", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "CategoryId");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
