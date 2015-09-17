namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectPlaceWithUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropIndex("dbo.Roles", new[] { "UserId" });
            AddColumn("dbo.Roles", "User_UserId", c => c.Int());
            AddForeignKey("dbo.Roles", "User_UserId", "dbo.Users", "UserId");
            CreateIndex("dbo.Roles", "User_UserId");
            DropColumn("dbo.Roles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.Roles", new[] { "User_UserId" });
            DropForeignKey("dbo.Roles", "User_UserId", "dbo.Users");
            DropColumn("dbo.Roles", "User_UserId");
            CreateIndex("dbo.Roles", "UserId");
            AddForeignKey("dbo.Roles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
