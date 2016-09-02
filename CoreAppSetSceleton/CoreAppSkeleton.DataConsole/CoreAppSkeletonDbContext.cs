﻿using CoreAppSkeleton.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoreAppSkeleton.DataConsole
{
    public class CoreAppSkeletonDbContext : DbContext, ICoreAppSkeletonDbContext
    {
        private IConfigurationRoot _config;

        public CoreAppSkeletonDbContext()
            : base()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            _config = builder.Build();
        }

        public CoreAppSkeletonDbContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<CoreAppModel> CoreAppModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}