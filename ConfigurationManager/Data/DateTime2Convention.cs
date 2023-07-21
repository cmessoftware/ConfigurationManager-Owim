﻿using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AppConfigurationManager.Data
{
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            this.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}