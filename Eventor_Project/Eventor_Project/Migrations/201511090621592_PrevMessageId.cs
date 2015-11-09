namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrevMessageId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "PrevMessageId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "PrevMessageId");
        }
    }
}
