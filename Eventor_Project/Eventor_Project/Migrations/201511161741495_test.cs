namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "About", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "About");
        }
    }
}
