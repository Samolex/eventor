namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Nickname", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Patronymic", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "ContactEmail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Places", "PlaceInfo", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Benefits", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Benefits", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Roles", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Roles", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
            AlterColumn("dbo.Roles", "Code", c => c.String());
            AlterColumn("dbo.Benefits", "Name", c => c.String());
            AlterColumn("dbo.Benefits", "Code", c => c.String());
            AlterColumn("dbo.Places", "PlaceInfo", c => c.String());
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "ContactEmail", c => c.String());
            AlterColumn("dbo.Users", "Patronymic", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Nickname", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
    }
}
