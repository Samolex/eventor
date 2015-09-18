namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetProjectModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Project_ProjectId" });
            DropIndex("dbo.Organizers", new[] { "UserId" });
            CreateTable(
                "dbo.UserOrganizers",
                c => new
                    {
                        UserOrganizerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserOrganizerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Role = c.String(),
                        MaxCount = c.Int(nullable: false),
                        MinCount = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.UserCustomers",
                c => new
                    {
                        UserCustomerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserCustomerId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
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
                        UserProjectId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Attitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserProjectId);
            
            AddColumn("dbo.Organizers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Organizers", "Title", c => c.String());
            AddColumn("dbo.Users", "Project_ProjectId", c => c.Int());
            DropIndex("dbo.UserCustomers", new[] { "CustomerId" });
            DropIndex("dbo.UserCustomers", new[] { "UserId" });
            DropIndex("dbo.Customers", new[] { "ProjectId" });
            DropIndex("dbo.UserOrganizers", new[] { "OrganizerId" });
            DropIndex("dbo.UserOrganizers", new[] { "UserId" });
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
            AddForeignKey("dbo.Organizers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
