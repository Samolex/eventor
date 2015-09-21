namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Users", "Material_MaterialId", c => c.Int());
            AddColumn("dbo.Users", "Money_MoneyId", c => c.Int());
            AddColumn("dbo.Users", "Project_ProjectId", c => c.Int());
            AddForeignKey("dbo.Users", "Material_MaterialId", "dbo.Materials", "MaterialId");
            AddForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys", "MoneyId");
            AddForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects", "ProjectId");
            CreateIndex("dbo.Users", "Material_MaterialId");
            CreateIndex("dbo.Users", "Money_MoneyId");
            CreateIndex("dbo.Users", "Project_ProjectId");
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
            DropIndex("dbo.Users", new[] { "Project_ProjectId" });
            DropIndex("dbo.Users", new[] { "Money_MoneyId" });
            DropIndex("dbo.Users", new[] { "Material_MaterialId" });
            DropForeignKey("dbo.ProjectComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProjectComments", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectNews", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Materials", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Organizers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys");
            DropForeignKey("dbo.Users", "Material_MaterialId", "dbo.Materials");
            DropColumn("dbo.Users", "Project_ProjectId");
            DropColumn("dbo.Users", "Money_MoneyId");
            DropColumn("dbo.Users", "Material_MaterialId");
            DropTable("dbo.UserProjects");
            DropTable("dbo.UserMoneys");
            DropTable("dbo.UserMaterials");
            DropTable("dbo.ProjectComments");
            DropTable("dbo.ProjectNews");
            DropTable("dbo.Moneys");
            DropTable("dbo.Materials");
            DropTable("dbo.Organizers");
            DropTable("dbo.Projects");
        }
    }
}
