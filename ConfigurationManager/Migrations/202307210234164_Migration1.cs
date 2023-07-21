namespace AppConfigurationManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Configuration", "Application_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.EnvironmentApplication", "Environment_EnvironmentId", "dbo.Environment");
            DropForeignKey("dbo.EnvironmentApplication", "Application_ApplicationId", "dbo.Application");
            DropForeignKey("dbo.Application", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserGroupUser", "UserGroup_UserGroupId", "dbo.UserGroup");
            DropForeignKey("dbo.UserGroupUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.User", "Action_ActionId", "dbo.Action");
            DropForeignKey("dbo.Application", "Profile_ProfileId", "dbo.Profile");
            DropForeignKey("dbo.UserGroup", "Profile_ProfileId", "dbo.Profile");
            DropIndex("dbo.User", new[] { "Action_ActionId" });
            DropIndex("dbo.Application", new[] { "User_UserId" });
            DropIndex("dbo.Application", new[] { "Profile_ProfileId" });
            DropIndex("dbo.Configuration", new[] { "Application_ApplicationId" });
            DropIndex("dbo.UserGroup", new[] { "Profile_ProfileId" });
            DropIndex("dbo.EnvironmentApplication", new[] { "Environment_EnvironmentId" });
            DropIndex("dbo.EnvironmentApplication", new[] { "Application_ApplicationId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.UserGroupUser", new[] { "UserGroup_UserGroupId" });
            DropIndex("dbo.UserGroupUser", new[] { "User_UserId" });
            DropTable("dbo.Action");
            DropTable("dbo.User");
            DropTable("dbo.Application");
            DropTable("dbo.Configuration");
            DropTable("dbo.Environment");
            DropTable("dbo.Role");
            DropTable("dbo.UserGroup");
            DropTable("dbo.Profile");
            DropTable("dbo.EnvironmentApplication");
            DropTable("dbo.RoleUser");
            DropTable("dbo.UserGroupUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserGroupUser",
                c => new
                    {
                        UserGroup_UserGroupId = c.String(nullable: false, maxLength: 128),
                        User_UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserGroup_UserGroupId, t.User_UserId });
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleId = c.String(nullable: false, maxLength: 128),
                        User_UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId });
            
            CreateTable(
                "dbo.EnvironmentApplication",
                c => new
                    {
                        Environment_EnvironmentId = c.String(nullable: false, maxLength: 128),
                        Application_ApplicationId = c.String(nullable: false, maxLength: 36, unicode: false),
                    })
                .PrimaryKey(t => new { t.Environment_EnvironmentId, t.Application_ApplicationId });
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Profile_ProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserGroupId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                        RoleDescription = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Environment",
                c => new
                    {
                        EnvironmentId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Url = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.Configuration",
                c => new
                    {
                        ConfigurationId = c.String(nullable: false, maxLength: 128),
                        Key = c.String(),
                        Value = c.String(),
                        ApplicationId = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                        Application_ApplicationId = c.String(maxLength: 36, unicode: false),
                    })
                .PrimaryKey(t => t.ConfigurationId);
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ApplicationId = c.String(nullable: false, maxLength: 36, unicode: false),
                        Name = c.String(),
                        Description = c.String(),
                        Version = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                        User_UserId = c.String(maxLength: 128),
                        Profile_ProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreateBy_UserId = c.String(),
                        UpdateBy_UserId = c.String(),
                        Action_ActionId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Action",
                c => new
                    {
                        ActionId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        CreateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateBy = c.String(),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.ActionId);
            
            CreateIndex("dbo.UserGroupUser", "User_UserId");
            CreateIndex("dbo.UserGroupUser", "UserGroup_UserGroupId");
            CreateIndex("dbo.RoleUser", "User_UserId");
            CreateIndex("dbo.RoleUser", "Role_RoleId");
            CreateIndex("dbo.EnvironmentApplication", "Application_ApplicationId");
            CreateIndex("dbo.EnvironmentApplication", "Environment_EnvironmentId");
            CreateIndex("dbo.UserGroup", "Profile_ProfileId");
            CreateIndex("dbo.Configuration", "Application_ApplicationId");
            CreateIndex("dbo.Application", "Profile_ProfileId");
            CreateIndex("dbo.Application", "User_UserId");
            CreateIndex("dbo.User", "Action_ActionId");
            AddForeignKey("dbo.UserGroup", "Profile_ProfileId", "dbo.Profile", "ProfileId");
            AddForeignKey("dbo.Application", "Profile_ProfileId", "dbo.Profile", "ProfileId");
            AddForeignKey("dbo.User", "Action_ActionId", "dbo.Action", "ActionId");
            AddForeignKey("dbo.UserGroupUser", "User_UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserGroupUser", "UserGroup_UserGroupId", "dbo.UserGroup", "UserGroupId", cascadeDelete: true);
            AddForeignKey("dbo.RoleUser", "User_UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Application", "User_UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.EnvironmentApplication", "Application_ApplicationId", "dbo.Application", "ApplicationId", cascadeDelete: true);
            AddForeignKey("dbo.EnvironmentApplication", "Environment_EnvironmentId", "dbo.Environment", "EnvironmentId", cascadeDelete: true);
            AddForeignKey("dbo.Configuration", "Application_ApplicationId", "dbo.Application", "ApplicationId");
        }
    }
}
