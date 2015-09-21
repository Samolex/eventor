using System.Data.Entity.Migrations;

namespace Eventor_Project.Migrations
{
    public partial class AddAutoRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserOrganizers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserOrganizers", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.UserCustomers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.UserOrganizers", new[] {"UserId"});
            DropIndex("dbo.UserOrganizers", new[] {"OrganizerId"});
            DropIndex("dbo.UserCustomers", new[] {"UserId"});
            DropIndex("dbo.UserCustomers", new[] {"CustomerId"});
            CreateTable(
                "dbo.OrganizerUsers",
                c => new
                {
                    Organizer_OrganizerId = c.Int(false),
                    User_UserId = c.Int(false)
                })
                .PrimaryKey(t => new {t.Organizer_OrganizerId, t.User_UserId})
                .ForeignKey("dbo.Organizers", t => t.Organizer_OrganizerId, true)
                .ForeignKey("dbo.Users", t => t.User_UserId, true)
                .Index(t => t.Organizer_OrganizerId)
                .Index(t => t.User_UserId);

            CreateTable(
                "dbo.CustomerUsers",
                c => new
                {
                    Customer_CustomerId = c.Int(false),
                    User_UserId = c.Int(false)
                })
                .PrimaryKey(t => new {t.Customer_CustomerId, t.User_UserId})
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, true)
                .ForeignKey("dbo.Users", t => t.User_UserId, true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.User_UserId);

            DropTable("dbo.UserOrganizers");
            DropTable("dbo.UserCustomers");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.UserCustomers",
                c => new
                {
                    UserCustomerId = c.Int(false, true),
                    UserId = c.Int(false),
                    CustomerId = c.Int(false)
                })
                .PrimaryKey(t => t.UserCustomerId);

            CreateTable(
                "dbo.UserOrganizers",
                c => new
                {
                    UserOrganizerId = c.Int(false, true),
                    UserId = c.Int(false),
                    OrganizerId = c.Int(false)
                })
                .PrimaryKey(t => t.UserOrganizerId);

            DropIndex("dbo.CustomerUsers", new[] {"User_UserId"});
            DropIndex("dbo.CustomerUsers", new[] {"Customer_CustomerId"});
            DropIndex("dbo.OrganizerUsers", new[] {"User_UserId"});
            DropIndex("dbo.OrganizerUsers", new[] {"Organizer_OrganizerId"});
            DropForeignKey("dbo.CustomerUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerUsers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrganizerUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OrganizerUsers", "Organizer_OrganizerId", "dbo.Organizers");
            DropTable("dbo.CustomerUsers");
            DropTable("dbo.OrganizerUsers");
            CreateIndex("dbo.UserCustomers", "CustomerId");
            CreateIndex("dbo.UserCustomers", "UserId");
            CreateIndex("dbo.UserOrganizers", "OrganizerId");
            CreateIndex("dbo.UserOrganizers", "UserId");
            AddForeignKey("dbo.UserCustomers", "CustomerId", "dbo.Customers", "CustomerId", true);
            AddForeignKey("dbo.UserCustomers", "UserId", "dbo.Users", "UserId", true);
            AddForeignKey("dbo.UserOrganizers", "OrganizerId", "dbo.Organizers", "OrganizerId", true);
            AddForeignKey("dbo.UserOrganizers", "UserId", "dbo.Users", "UserId", true);
        }
    }
}