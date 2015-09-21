using System.Data.Entity.Migrations;

namespace Eventor_Project.Migrations
{
    public partial class RemoveMoney : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys");
            DropForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] {"Money_MoneyId"});
            DropIndex("dbo.Moneys", new[] {"ProjectId"});
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
                    UserMoneyId = c.Int(false, true),
                    UserId = c.Int(false),
                    MoneyId = c.Int(false),
                    Ammount = c.Int(false)
                })
                .PrimaryKey(t => t.UserMoneyId);

            CreateTable(
                "dbo.Moneys",
                c => new
                {
                    MoneyId = c.Int(false, true),
                    ProjectId = c.Int(false),
                    Title = c.Int(false),
                    RequiredAmount = c.Int(false),
                    CurrentAmount = c.Int(false)
                })
                .PrimaryKey(t => t.MoneyId);

            AddColumn("dbo.Users", "Money_MoneyId", c => c.Int());
            CreateIndex("dbo.Moneys", "ProjectId");
            CreateIndex("dbo.Users", "Money_MoneyId");
            AddForeignKey("dbo.Moneys", "ProjectId", "dbo.Projects", "ProjectId", true);
            AddForeignKey("dbo.Users", "Money_MoneyId", "dbo.Moneys", "MoneyId");
        }
    }
}