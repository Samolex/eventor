namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PlaceId);
            
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
            DropIndex("dbo.Users", new[] { "PlaceOfLiving_PlaceId" });
            DropIndex("dbo.Users", new[] { "PlaceOfStudy_PlaceId" });
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PlaceOfLiving_PlaceId", "dbo.Places");
            DropForeignKey("dbo.Users", "PlaceOfStudy_PlaceId", "dbo.Places");
            DropColumn("dbo.Users", "PlaceOfLiving_PlaceId");
            DropColumn("dbo.Users", "PlaceOfStudy_PlaceId");
            DropColumn("dbo.Users", "BirthDate");
            DropColumn("dbo.Users", "Sex");
            DropColumn("dbo.Users", "Patronymic");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Nickname");
            DropTable("dbo.Contacts");
            DropTable("dbo.Places");
        }
    }
}
