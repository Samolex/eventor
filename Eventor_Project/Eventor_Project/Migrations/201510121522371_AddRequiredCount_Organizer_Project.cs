namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredCount_Organizer_Project : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizers", "RequiredCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizers", "RequiredCount");
        }
    }
}
