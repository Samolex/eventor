namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMoney : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys");
            DropForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "Money_MoneyId" });
            DropIndex("dbo.Moneys", new[] { "ProjectId" });
            DropColumn("dbo.Users", "Money_MoneyId");
            DropTable("dbo.Moneys");
            DropTable("dbo.UserMoneys");
        }
        
        public override void Down()
        {
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
                "dbo.Moneys",
                c => new
                    {
                        MoneyId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                        RequiredAmount = c.Int(nullable: false),
                        CurrentAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoneyId);
            
            AddColumn("dbo.Users", "Money_MoneyId", c => c.Int());
            CreateIndex("dbo.Moneys", "ProjectId");
            CreateIndex("dbo.Users", "Money_MoneyId");
            AddForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys", "MoneyId");
        }
    }
}
