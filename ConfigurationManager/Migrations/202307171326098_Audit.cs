namespace ConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Audit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "EnvironmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Application", "CreateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Application", "UpdateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Application", "CreateBy_Id", c => c.Int());
            AddColumn("dbo.Application", "ModifiyBy_Id", c => c.Int());
            AddColumn("dbo.AppUser", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.AppUser", "PermissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Application", "CreateBy_Id");
            CreateIndex("dbo.Application", "ModifiyBy_Id");
            AddForeignKey("dbo.Application", "CreateBy_Id", "dbo.AppUser", "Id");
            AddForeignKey("dbo.Application", "ModifiyBy_Id", "dbo.AppUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "ModifiyBy_Id", "dbo.AppUser");
            DropForeignKey("dbo.Application", "CreateBy_Id", "dbo.AppUser");
            DropIndex("dbo.Application", new[] { "ModifiyBy_Id" });
            DropIndex("dbo.Application", new[] { "CreateBy_Id" });
            DropColumn("dbo.AppUser", "PermissionId");
            DropColumn("dbo.AppUser", "RoleId");
            DropColumn("dbo.Application", "ModifiyBy_Id");
            DropColumn("dbo.Application", "CreateBy_Id");
            DropColumn("dbo.Application", "UpdateOn");
            DropColumn("dbo.Application", "CreateOn");
            DropColumn("dbo.Application", "EnvironmentId");
            DropColumn("dbo.Application", "UserId");
        }
    }
}
