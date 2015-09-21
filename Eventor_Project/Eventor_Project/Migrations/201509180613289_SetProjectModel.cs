using System.Data.Entity.Migrations;

namespace Eventor_Project.Migrations
{
    public partial class SetProjectModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] {"Project_ProjectId"});
            DropIndex("dbo.Organizers", new[] {"UserId"});
            CreateTable(
                "dbo.UserOrganizers",
                c => new
                {
                    UserOrganizerId = c.Int(false, true),
                    UserId = c.Int(false),
                    OrganizerId = c.Int(false)
                })
                .PrimaryKey(t => t.UserOrganizerId)
                .ForeignKey("dbo.Users", t => t.UserId, true)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, true)
                .Index(t => t.UserId)
                .Index(t => t.OrganizerId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(false, true),
                    ProjectId = c.Int(false),
                    Role = c.String(),
                    MaxCount = c.Int(false),
                    MinCount = c.Int(false),
                    Description = c.String()
                })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, true)
                .Index(t => t.ProjectId);

            CreateTable(
                "dbo.UserCustomers",
                c => new
                {
                    UserCustomerId = c.Int(false, true),
                    UserId = c.Int(false),
                    CustomerId = c.Int(false)
                })
                .PrimaryKey(t => t.UserCustomerId)
                .ForeignKey("dbo.Users", t => t.UserId, true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, true)
                .Index(t => t.UserId)
                .Index(t => t.CustomerId);

            AddColumn("dbo.Organizers", "Name", c => c.String());
            DropColumn("dbo.Users", "Project_ProjectId");
            DropColumn("dbo.Organizers", "Title");
            DropColumn("dbo.Organizers", "UserId");
            DropTable("dbo.UserProjects");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                {
                    UserProjectId = c.Int(false, true),
                    UserId = c.Int(false),
                    ProjectId = c.Int(false),
                    Attitude = c.Int(false)
                })
                .PrimaryKey(t => t.UserProjectId);

            AddColumn("dbo.Organizers", "UserId", c => c.Int(false));
            AddColumn("dbo.Organizers", "Title", c => c.String());
            AddColumn("dbo.Users", "Project_ProjectId", c => c.Int());
            DropIndex("dbo.UserCustomers", new[] {"CustomerId"});
            DropIndex("dbo.UserCustomers", new[] {"UserId"});
            DropIndex("dbo.Customers", new[] {"ProjectId"});
            DropIndex("dbo.UserOrganizers", new[] {"OrganizerId"});
            DropIndex("dbo.UserOrganizers", new[] {"UserId"});
            DropForeignKey("dbo.UserCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.UserCustomers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Customers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserOrganizers", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.UserOrganizers", "UserId", "dbo.Users");
            DropColumn("dbo.Organizers", "Name");
            DropTable("dbo.UserCustomers");
            DropTable("dbo.Customers");
            DropTable("dbo.UserOrganizers");
            CreateIndex("dbo.Organizers", "UserId");
            CreateIndex("dbo.Users", "Project_ProjectId");
            AddForeignKey("dbo.Organizers", "UserId", "dbo.Users", "UserId", true);
            AddForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}