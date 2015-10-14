namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Requried_Fields_In_ProjectModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String());
            AlterColumn("dbo.Projects", "Headquarter", c => c.String());
            AlterColumn("dbo.Projects", "Place", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Place", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Headquarter", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
