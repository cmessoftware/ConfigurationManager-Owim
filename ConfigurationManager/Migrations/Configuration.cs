namespace AppConfigurationManager.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.CMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

    }
}
