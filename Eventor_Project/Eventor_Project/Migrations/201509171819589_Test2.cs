namespace Eventor_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Material_MaterialId", "dbo.Materials");
            DropIndex("dbo.Users", new[] { "Material_MaterialId" });
            AddForeignKey("dbo.UserMaterials", "MaterialId", "dbo.Materials", "MaterialId", cascadeDelete: true);
            CreateIndex("dbo.UserMaterials", "MaterialId");
            DropColumn("dbo.Users", "Material_MaterialId");
            DropColumn("dbo.Materials", "CurrentAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "CurrentAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Material_MaterialId", c => c.Int());
            DropIndex("dbo.UserMaterials", new[] { "MaterialId" });
            DropForeignKey("dbo.UserMaterials", "MaterialId", "dbo.Materials");
            CreateIndex("dbo.Users", "Material_MaterialId");
            AddForeignKey("dbo.Users", "Material_MaterialId", "dbo.Materials", "MaterialId");
        }
    }
}
