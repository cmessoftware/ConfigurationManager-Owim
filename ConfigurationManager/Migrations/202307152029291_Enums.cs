namespace ConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppEnvironment", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.AppPermission", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.AppRole", "RoleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppRole", "RoleId", c => c.String());
            AlterColumn("dbo.AppPermission", "Type", c => c.String());
            DropColumn("dbo.AppEnvironment", "Type");
        }
    }
}
