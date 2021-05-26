// <copyright file="MyDbContext.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Providers
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> option)
            : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(x => x.MigrationsHistoryTable("__MigrationsHistory"));
        }
    }
}
