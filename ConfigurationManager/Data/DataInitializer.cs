using AppConfigurationManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AppConfigurationManager.Data
{
    internal class DataInitializer : CreateDatabaseIfNotExists<CMDbContext>
    {
        protected override void Seed(CMDbContext context)
        { }
    }
}
