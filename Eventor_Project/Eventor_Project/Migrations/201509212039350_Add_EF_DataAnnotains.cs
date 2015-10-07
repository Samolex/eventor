namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_EF_DataAnnotains : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "AddedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ChangeTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Materials", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Projects", "Headquarter", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Place", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Organizers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectNews", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectNews", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectComments", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectComments", "Body", c => c.String());
            AlterColumn("dbo.ProjectNews", "Body", c => c.String());
            AlterColumn("dbo.ProjectNews", "Title", c => c.String());
            AlterColumn("dbo.Organizers", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Projects", "Place", c => c.String());
            AlterColumn("dbo.Projects", "Headquarter", c => c.String());
            AlterColumn("dbo.Projects", "ShortDescription", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            AlterColumn("dbo.Materials", "Title", c => c.String());
            DropColumn("dbo.Projects", "ChangeTime");
            DropColumn("dbo.Projects", "AddedTime");
        }
    }
}
