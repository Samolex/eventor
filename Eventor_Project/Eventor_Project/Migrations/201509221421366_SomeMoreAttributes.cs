namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMoreAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Benefits", "Code", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "Code", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Benefits", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 200));
        }
    }
}
