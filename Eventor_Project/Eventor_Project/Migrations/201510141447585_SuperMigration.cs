namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Nickname = c.String(maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Sex = c.Int(nullable: false),
                        ContactEmail = c.String(maxLength: 200),
                        PhoneNumber = c.String(maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        Birthdate = c.DateTime(nullable: false),
                        PlaceOfLiving_PlaceId = c.Int(),
                        PlaceOfStudy_PlaceId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Places", t => t.PlaceOfLiving_PlaceId)
                .ForeignKey("dbo.Places", t => t.PlaceOfStudy_PlaceId)
                .Index(t => t.PlaceOfLiving_PlaceId)
                .Index(t => t.PlaceOfStudy_PlaceId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        PlaceInfo = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Benefits",
                c => new
                    {
                        BenefitId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BenefitId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserMaterials",
                c => new
                    {
                        UserMaterialId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserMaterialId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        RequiredAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Headquarter = c.String(),
                        Place = c.String(),
                        CategoryId = c.Int(),
                        OrganizationDate = c.DateTime(),
                        EventDate = c.DateTime(),
                        AddedTime = c.DateTime(nullable: false),
                        ChangeTime = c.DateTime(nullable: false),
                        Author_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.Author_UserId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.Author_UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        OrganizerId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        RequiredCount = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OrganizerId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectNews",
                c => new
                    {
                        ProjectNewsId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectNewsId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
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
                "dbo.ProjectComments",
                c => new
                    {
                        ProjectCommentId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectCommentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BenefitUsers",
                c => new
                    {
                        Benefit_BenefitId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Benefit_BenefitId, t.User_UserId })
                .ForeignKey("dbo.Benefits", t => t.Benefit_BenefitId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Benefit_BenefitId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.OrganizerUsers",
                c => new
                    {
                        Organizer_OrganizerId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organizer_OrganizerId, t.User_UserId })
                .ForeignKey("dbo.Organizers", t => t.Organizer_OrganizerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Organizer_OrganizerId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.CustomerUsers",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.User_UserId })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerUsers", new[] { "User_UserId" });
            DropIndex("dbo.CustomerUsers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OrganizerUsers", new[] { "User_UserId" });
            DropIndex("dbo.OrganizerUsers", new[] { "Organizer_OrganizerId" });
            DropIndex("dbo.RoleUsers", new[] { "User_UserId" });
            DropIndex("dbo.RoleUsers", new[] { "Role_RoleId" });
            DropIndex("dbo.BenefitUsers", new[] { "User_UserId" });
            DropIndex("dbo.BenefitUsers", new[] { "Benefit_BenefitId" });
            DropIndex("dbo.ProjectComments", new[] { "UserId" });
            DropIndex("dbo.ProjectComments", new[] { "ProjectId" });
            DropIndex("dbo.Customers", new[] { "ProjectId" });
            DropIndex("dbo.ProjectNews", new[] { "ProjectId" });
            DropIndex("dbo.Organizers", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            DropIndex("dbo.Projects", new[] { "Author_UserId" });
            DropIndex("dbo.Materials", new[] { "ProjectId" });
            DropIndex("dbo.UserMaterials", new[] { "MaterialId" });
            DropIndex("dbo.UserMaterials", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "PlaceOfStudy_PlaceId" });
            DropIndex("dbo.Users", new[] { "PlaceOfLiving_PlaceId" });
            DropForeignKey("dbo.CustomerUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.CustomerUsers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrganizerUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.OrganizerUsers", "Organizer_OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.RoleUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.BenefitUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.BenefitUsers", "Benefit_BenefitId", "dbo.Benefits");
            DropForeignKey("dbo.ProjectComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProjectComments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Customers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectNews", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Projects", "Author_UserId", "dbo.Users");
            DropForeignKey("dbo.Materials", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserMaterials", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.UserMaterials", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "PlaceOfStudy_PlaceId", "dbo.Places");
            DropForeignKey("dbo.Users", "PlaceOfLiving_PlaceId", "dbo.Places");
            DropTable("dbo.CustomerUsers");
            DropTable("dbo.OrganizerUsers");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.BenefitUsers");
            DropTable("dbo.ProjectComments");
            DropTable("dbo.Customers");
            DropTable("dbo.ProjectNews");
            DropTable("dbo.Organizers");
            DropTable("dbo.Categories");
            DropTable("dbo.Projects");
            DropTable("dbo.Materials");
            DropTable("dbo.UserMaterials");
            DropTable("dbo.Roles");
            DropTable("dbo.Benefits");
            DropTable("dbo.Places");
            DropTable("dbo.Users");
        }
    }
}
