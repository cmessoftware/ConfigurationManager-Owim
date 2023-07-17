using ConfigurationManager.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ConfigurationManager.Data
{
    public class CMDbContext : DbContext
    {
        public CMDbContext()
            : base("name=CMConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CMDbContext>());
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<AppEnvironment> AppEnvironment { get; set; }
        public virtual DbSet<AppPermission> AppPermission { get; set; }
        public virtual DbSet<AppRole> AppRole { get; set; }
        public virtual DbSet<AppConfiguration> AppConfiguration { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}