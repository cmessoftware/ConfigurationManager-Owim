namespace AppConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaLaptop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppAction",
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
                "dbo.AppUser",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 36),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        CreateBy_UserId = c.String(),
                        UpdateBy_UserId = c.String(),
                        AppAction_ActionId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AppAction", t => t.AppAction_ActionId)
                .Index(t => t.AppAction_ActionId);
            
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
                        AppUser_UserId = c.String(maxLength: 36),
                        AppProfile_ProfileId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.AppUser", t => t.AppUser_UserId)
                .ForeignKey("dbo.AppProfile", t => t.AppProfile_ProfileId)
                .Index(t => t.AppUser_UserId)
                .Index(t => t.AppProfile_ProfileId);
            
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
                "dbo.AppRole",
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
                "dbo.AppUserGroup",
                c => new
                    {
                        UserGroupId = c.String(nullable: false, maxLength: 36),
                        Name = c.String(),
                        AppProfile_ProfileId = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.UserGroupId)
                .ForeignKey("dbo.AppProfile", t => t.AppProfile_ProfileId)
                .Index(t => t.AppProfile_ProfileId);
            
            CreateTable(
                "dbo.AppProfile",
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
                "dbo.AppRoleAppUser",
                c => new
                    {
                        AppRole_RoleId = c.String(nullable: false, maxLength: 36),
                        AppUser_UserId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.AppRole_RoleId, t.AppUser_UserId })
                .ForeignKey("dbo.AppRole", t => t.AppRole_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.AppUser_UserId, cascadeDelete: true)
                .Index(t => t.AppRole_RoleId)
                .Index(t => t.AppUser_UserId);
            
            CreateTable(
                "dbo.AppUserGroupAppUser",
                c => new
                    {
                        AppUserGroup_UserGroupId = c.String(nullable: false, maxLength: 36),
                        AppUser_UserId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => new { t.AppUserGroup_UserGroupId, t.AppUser_UserId })
                .ForeignKey("dbo.AppUserGroup", t => t.AppUserGroup_UserGroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppUser", t => t.AppUser_UserId, cascadeDelete: true)
                .Index(t => t.AppUserGroup_UserGroupId)
                .Index(t => t.AppUser_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserGroup", "AppProfile_ProfileId", "dbo.AppProfile");
            DropForeignKey("dbo.Application", "AppProfile_ProfileId", "dbo.AppProfile");
            DropForeignKey("dbo.AppUser", "AppAction_ActionId", "dbo.AppAction");
            DropForeignKey("dbo.AppUserGroupAppUser", "AppUser_UserId", "dbo.AppUser");
            DropForeignKey("dbo.AppUserGroupAppUser", "AppUserGroup_UserGroupId", "dbo.AppUserGroup");
            DropForeignKey("dbo.AppRoleAppUser", "AppUser_UserId", "dbo.AppUser");
            DropForeignKey("dbo.AppRoleAppUser", "AppRole_RoleId", "dbo.AppRole");
            DropForeignKey("dbo.Application", "AppUser_UserId", "dbo.AppUser");
            DropForeignKey("dbo.AppEnvironmentApplication", "Application_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.AppEnvironmentApplication", "AppEnvironment_AppEnvironmentId", "dbo.AppEnvironment");
            DropForeignKey("dbo.AppConfiguration", "ApplicationId", "dbo.Application");
            DropIndex("dbo.AppUserGroupAppUser", new[] { "AppUser_UserId" });
            DropIndex("dbo.AppUserGroupAppUser", new[] { "AppUserGroup_UserGroupId" });
            DropIndex("dbo.AppRoleAppUser", new[] { "AppUser_UserId" });
            DropIndex("dbo.AppRoleAppUser", new[] { "AppRole_RoleId" });
            DropIndex("dbo.AppEnvironmentApplication", new[] { "Application_ApplicationId" });
            DropIndex("dbo.AppEnvironmentApplication", new[] { "AppEnvironment_AppEnvironmentId" });
            DropIndex("dbo.AppUserGroup", new[] { "AppProfile_ProfileId" });
            DropIndex("dbo.AppConfiguration", new[] { "ApplicationId" });
            DropIndex("dbo.Application", new[] { "AppProfile_ProfileId" });
            DropIndex("dbo.Application", new[] { "AppUser_UserId" });
            DropIndex("dbo.AppUser", new[] { "AppAction_ActionId" });
            DropTable("dbo.AppUserGroupAppUser");
            DropTable("dbo.AppRoleAppUser");
            DropTable("dbo.AppEnvironmentApplication");
            DropTable("dbo.AppProfile");
            DropTable("dbo.AppUserGroup");
            DropTable("dbo.AppRole");
            DropTable("dbo.AppEnvironment");
            DropTable("dbo.AppConfiguration");
            DropTable("dbo.Application");
            DropTable("dbo.AppUser");
            DropTable("dbo.AppAction");
        }
    }
}
