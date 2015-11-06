namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ReceiverNick", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReceiverNick");
        }
    }
}
