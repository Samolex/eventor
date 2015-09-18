namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectModel : DbMigration
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
                        Material_MaterialId = c.Int(),
                        Money_MoneyId = c.Int(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Places", t => t.PlaceOfStudy_PlaceId)
                .ForeignKey("dbo.Places", t => t.PlaceOfLiving_PlaceId)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId)
                .ForeignKey("dbo.Moneys", t => t.Money_MoneyId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.PlaceOfStudy_PlaceId)
                .Index(t => t.PlaceOfLiving_PlaceId)
                .Index(t => t.Material_MaterialId)
                .Index(t => t.Money_MoneyId)
                .Index(t => t.Project_ProjectId);
            
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
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        OrganizationDate = c.DateTime(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        OrganizerId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrganizerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.String(),
                        RequiredAmount = c.Int(nullable: false),
                        CurrentAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Moneys",
                c => new
                    {
                        MoneyId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                        RequiredAmount = c.Int(nullable: false),
                        CurrentAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoneyId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectNews",
                c => new
                    {
                        ProjectNewsId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ProjectNewsId)
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
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ProjectCommentId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.UserMaterials",
                c => new
                    {
                        UserMaterialId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserMaterialId);
            
            CreateTable(
                "dbo.UserMoneys",
                c => new
                    {
                        UserMoneyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MoneyId = c.Int(nullable: false),
                        Ammount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserMoneyId);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectComments", new[] { "UserId" });
            DropIndex("dbo.ProjectComments", new[] { "ProjectId" });
            DropIndex("dbo.ProjectNews", new[] { "ProjectId" });
            DropIndex("dbo.Moneys", new[] { "ProjectId" });
            DropIndex("dbo.Materials", new[] { "ProjectId" });
            DropIndex("dbo.Organizers", new[] { "ProjectId" });
            DropIndex("dbo.Organizers", new[] { "UserId" });
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Project_ProjectId" });
            DropIndex("dbo.Users", new[] { "Money_MoneyId" });
            DropIndex("dbo.Users", new[] { "Material_MaterialId" });
            DropIndex("dbo.Users", new[] { "PlaceOfLiving_PlaceId" });
            DropIndex("dbo.Users", new[] { "PlaceOfStudy_PlaceId" });
            DropForeignKey("dbo.ProjectComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProjectComments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectNews", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Materials", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Contacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys");
            DropForeignKey("dbo.Users", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Users", "PlaceOfLiving_PlaceId", "dbo.Places");
            DropForeignKey("dbo.Users", "PlaceOfStudy_PlaceId", "dbo.Places");
            DropTable("dbo.UserProjects");
            DropTable("dbo.UserMoneys");
            DropTable("dbo.UserMaterials");
            DropTable("dbo.Categories");
            DropTable("dbo.ProjectComments");
            DropTable("dbo.ProjectNews");
            DropTable("dbo.Moneys");
            DropTable("dbo.Materials");
            DropTable("dbo.Organizers");
            DropTable("dbo.Projects");
            DropTable("dbo.Contacts");
            DropTable("dbo.Roles");
            DropTable("dbo.Places");
            DropTable("dbo.Users");
        }
    }
}
