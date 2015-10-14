namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_datetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "OrganizationDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "EventDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "EventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "OrganizationDate", c => c.DateTime(nullable: false));
        }
    }
}
