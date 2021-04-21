// <copyright file="InitialCatalog.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Providers
{
    using System.Data.SqlClient;
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using MyMail.Domains.Entities;
    using MyMail.Domains.Providers;

    public class InitialCatalog : Repository<BaseEntity>, IInitialCatalog
    {
        public InitialCatalog(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public bool Create()
        {
            string connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            connectionString = connectionString.Replace("myMail", "master");
            using var cnn = new SqlConnection(connectionString);
            var affectedRows = cnn.QueryFirst<int>(this.GetQuery("CreateDataBase"));
            return affectedRows == 1 ? true : false;
        }
    }
}
