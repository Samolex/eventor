namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senderNick : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderNick", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SenderNick");
        }
    }
}
