namespace ConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppConfiguration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        ApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppEnvironment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        Application_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .Index(t => t.Application_Id);
            
            CreateTable(
                "dbo.AppUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(),
                        Application_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Application", t => t.Application_Id)
                .Index(t => t.Application_Id);
            
            CreateTable(
                "dbo.AppPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDescription = c.String(),
                        RoleId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppPermissionAppUser",
                c => new
                    {
                        AppPermission_Id = c.Int(nullable: false),
                        AppUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppPermission_Id, t.AppUser_Id })
                .ForeignKey("dbo.AppPermission", t => t.AppPermission_Id, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id, cascadeDelete: true)
                .Index(t => t.AppPermission_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.AppRoleAppUser",
                c => new
                    {
                        AppRole_Id = c.Int(nullable: false),
                        AppUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppRole_Id, t.AppUser_Id })
                .ForeignKey("dbo.AppRole", t => t.AppRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.AppUser_Id, cascadeDelete: true)
                .Index(t => t.AppRole_Id)
                .Index(t => t.AppUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppConfiguration", "ApplicationId", "dbo.Application");
            DropForeignKey("dbo.AppUser", "Application_Id", "dbo.Application");
            DropForeignKey("dbo.AppRoleAppUser", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppRoleAppUser", "AppRole_Id", "dbo.AppRole");
            DropForeignKey("dbo.AppPermissionAppUser", "AppUser_Id", "dbo.AppUser");
            DropForeignKey("dbo.AppPermissionAppUser", "AppPermission_Id", "dbo.AppPermission");
            DropForeignKey("dbo.AppEnvironment", "Application_Id", "dbo.Application");
            DropIndex("dbo.AppRoleAppUser", new[] { "AppUser_Id" });
            DropIndex("dbo.AppRoleAppUser", new[] { "AppRole_Id" });
            DropIndex("dbo.AppPermissionAppUser", new[] { "AppUser_Id" });
            DropIndex("dbo.AppPermissionAppUser", new[] { "AppPermission_Id" });
            DropIndex("dbo.AppUser", new[] { "Application_Id" });
            DropIndex("dbo.AppEnvironment", new[] { "Application_Id" });
            DropIndex("dbo.AppConfiguration", new[] { "ApplicationId" });
            DropTable("dbo.AppRoleAppUser");
            DropTable("dbo.AppPermissionAppUser");
            DropTable("dbo.AppRole");
            DropTable("dbo.AppPermission");
            DropTable("dbo.AppUser");
            DropTable("dbo.AppEnvironment");
            DropTable("dbo.Application");
            DropTable("dbo.AppConfiguration");
        }
    }
}
