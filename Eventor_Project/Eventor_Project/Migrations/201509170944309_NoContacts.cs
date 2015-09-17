namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoContacts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            AddColumn("dbo.Users", "ContactEmail", c => c.String());
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactsId = c.Int(nullable: false, identity: true),
                        ContactEmail = c.String(),
                        PhoneNumber = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactsId);
            
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "ContactEmail");
            CreateIndex("dbo.Contacts", "UserId");
            AddForeignKey("dbo.Contacts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
