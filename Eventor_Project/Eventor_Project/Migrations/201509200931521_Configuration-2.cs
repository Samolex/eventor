namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Benefits",
                c => new
                    {
                        BenefitId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BenefitId);
            
            CreateTable(
                "dbo.UserBenefits",
                c => new
                    {
                        UserBenefitId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BenefitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserBenefitId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Benefits", t => t.BenefitId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BenefitId);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BenefitUsers", new[] { "User_UserId" });
            DropIndex("dbo.BenefitUsers", new[] { "Benefit_BenefitId" });
            DropIndex("dbo.UserBenefits", new[] { "BenefitId" });
            DropIndex("dbo.UserBenefits", new[] { "UserId" });
            DropForeignKey("dbo.BenefitUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.BenefitUsers", "Benefit_BenefitId", "dbo.Benefits");
            DropForeignKey("dbo.UserBenefits", "BenefitId", "dbo.Benefits");
            DropForeignKey("dbo.UserBenefits", "UserId", "dbo.Users");
            DropTable("dbo.BenefitUsers");
            DropTable("dbo.UserBenefits");
            DropTable("dbo.Benefits");
        }
    }
}
