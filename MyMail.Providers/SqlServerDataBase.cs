// <copyright file="SqlServerDataBase.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Providers
{
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using MyMail.Domains.Providers;

    public class SqlServerDataBase : ISqlServerDataBase
    {
        public IConfiguration Configuration { get; set; }

        public SqlConnection GetDatabaseConnection() => new SqlConnection(this.Configuration.GetConnectionString("DefaultConnection"));

        public string GetQuery(string nameFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = @"MyMail.Providers.SQL.{0}.sql";

            using Stream stream = assembly.GetManifestResourceStream(string.Format(resourceName, nameFile));
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
