using AppConfigurationManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AppConfigurationManager.Data
{
    public class CMDbContext : DbContext
    {
        public CMDbContext()
            : base("name=CMConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CMDbContext>());
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Models.AppEnvironment> Environments { get; set; }
        public virtual DbSet<Models.AppAction> Actions { get; set; }
        public virtual DbSet<AppRole> Roles { get; set; }
        public virtual DbSet<AppConfiguration> Configurations { get; set; }
        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<AppUserGroup> UserGroups { get; set; }
        public virtual DbSet<AppProfile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new DateTime2Convention());

            //modelBuilder.Entity<Application>().Property(x => x.ApplicationId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<AppConfiguration>().Property(x => x.AppConfigurationId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<AppConfiguration>().
            //             HasRequired(x => x.Application).
            //             WithMany(x => x.Configurations).
            //             HasForeignKey(x => x.ApplicationId);

            //modelBuilder.Entity<AppEnvironment>().Property(x => x.AppEnvironmentId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<Profile>().Property(x => x.ProfileId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<Role>().Property(x => x.RoleId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<User>().Property(x => x.UserId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");

            //modelBuilder.Entity<UserGroup>().Property(x => x.UserGroupId).
            //             HasMaxLength(36).
            //             HasColumnType("varchar");
        }
    }


}