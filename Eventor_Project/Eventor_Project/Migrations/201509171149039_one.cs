namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Nickname = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Sex = c.Int(nullable: false),
                        PlaceOfStudy_PlaceId = c.Int(),
                        PlaceOfLiving_PlaceId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Places", t => t.PlaceOfStudy_PlaceId)
                .ForeignKey("dbo.Places", t => t.PlaceOfLiving_PlaceId)
                .Index(t => t.PlaceOfStudy_PlaceId)
                .Index(t => t.PlaceOfLiving_PlaceId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactsId = c.Int(nullable: false, identity: true),
                        ContactEmail = c.String(),
                        PhoneNumber = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactsId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "PlaceOfLiving_PlaceId" });
            DropIndex("dbo.Users", new[] { "PlaceOfStudy_PlaceId" });
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PlaceOfLiving_PlaceId", "dbo.Places");
            DropForeignKey("dbo.Users", "PlaceOfStudy_PlaceId", "dbo.Places");
            DropTable("dbo.Contacts");
            DropTable("dbo.Roles");
            DropTable("dbo.Places");
            DropTable("dbo.Users");
        }
    }
}
