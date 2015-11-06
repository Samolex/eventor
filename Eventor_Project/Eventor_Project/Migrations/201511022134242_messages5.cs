namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messages5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DepartureTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DepartureTime");
        }
    }
}
