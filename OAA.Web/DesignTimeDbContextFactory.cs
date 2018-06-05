﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OAA.Data;
using System.IO;

namespace OAA.Web
{
    public class DesignTimeDbContextFactory:  IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = configuration.GetConnectionString("NpgConnection");
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("OAA.Web"));
            return new ApplicationContext(builder.Options);
        }
    }
}
