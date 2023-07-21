namespace AppConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ActionId = c.String(nullable: false, maxLength: 36),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ActionId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        CreateBy_UserId = c.String(),
                        UpdateBy_UserId = c.String(),
                        Action_ActionId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Action", t => t.Action_ActionId)
                .Index(t => t.Action_ActionId);
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        Description = c.String(),
                        Version = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                        User_UserId = c.String(maxLength: 36),
                        Profile_ProfileId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .ForeignKey("dbo.Profile", t => t.Profile_ProfileId)
                .Index(t => t.User_UserId)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.AppConfiguration",
                c => new
                    {
                        AppConfigurationId = c.String(nullable: false, maxLength: 36),
                        Key = c.String(),
                        Value = c.String(),
                        ApplicationId = c.String(maxLength: 36),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.AppConfigurationId)
                .ForeignKey("dbo.Application", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AppEnvironment",
                c => new
                    {
                        AppEnvironmentId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.AppEnvironmentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 36),
                        RoleName = c.String(),
                        RoleDescription = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        Profile_ProfileId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.UserGroupId)
                .ForeignKey("dbo.Profile", t => t.Profile_ProfileId)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.AppEnvironmentApplication",
                c => new
                    {
                        AppEnvironment_AppEnvironmentId = c.String(nullable: false, maxLength: 36),
                        Application_ApplicationId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.AppEnvironment_AppEnvironmentId, t.Application_ApplicationId })
                .ForeignKey("dbo.AppEnvironment", t => t.AppEnvironment_AppEnvironmentId, cascadeDelete: true)
                .ForeignKey("dbo.Application", t => t.Application_ApplicationId, cascadeDelete: true)
                .Index(t => t.AppEnvironment_AppEnvironmentId)
                .Index(t => t.Application_ApplicationId);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleId = c.String(nullable: false, maxLength: 36),
                        User_UserId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserGroupUser",
                c => new
                    {
                        UserGroup_UserGroupId = c.String(nullable: false, maxLength: 36),
                        User_UserId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.UserGroup_UserGroupId, t.User_UserId })
                .ForeignKey("dbo.UserGroup", t => t.UserGroup_UserGroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.UserGroup_UserGroupId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGroup", "Profile_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.Application", "Profile_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.User", "Action_ActionId", "dbo.Action");
            DropForeignKey("dbo.UserGroupUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserGroupUser", "UserGroup_UserGroupId", "dbo.UserGroup");
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Application", "User_UserId", "dbo.User");
            DropForeignKey("dbo.AppEnvironmentApplication", "Application_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.AppEnvironmentApplication", "AppEnvironment_AppEnvironmentId", "dbo.AppEnvironment");
            DropForeignKey("dbo.AppConfiguration", "ApplicationId", "dbo.Application");
            DropIndex("dbo.UserGroupUser", new[] { "User_UserId" });
            DropIndex("dbo.UserGroupUser", new[] { "UserGroup_UserGroupId" });
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.AppEnvironmentApplication", new[] { "Application_ApplicationId" });
            DropIndex("dbo.AppEnvironmentApplication", new[] { "AppEnvironment_AppEnvironmentId" });
            DropIndex("dbo.UserGroup", new[] { "Profile_ProfileId" });
            DropIndex("dbo.AppConfiguration", new[] { "ApplicationId" });
            DropIndex("dbo.Application", new[] { "Profile_ProfileId" });
            DropIndex("dbo.Application", new[] { "User_UserId" });
            DropIndex("dbo.User", new[] { "Action_ActionId" });
            DropTable("dbo.UserGroupUser");
            DropTable("dbo.RoleUser");
            DropTable("dbo.AppEnvironmentApplication");
            DropTable("dbo.Profile");
            DropTable("dbo.UserGroup");
            DropTable("dbo.Role");
            DropTable("dbo.AppEnvironment");
            DropTable("dbo.AppConfiguration");
            DropTable("dbo.Application");
            DropTable("dbo.User");
            DropTable("dbo.Action");
        }
    }
}
