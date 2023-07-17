namespace ConfigurationManager.Migrations
{
    using ConfigurationManager.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.CMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

    }
}
