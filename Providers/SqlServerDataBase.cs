// <copyright file="SqlServerDataBase.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Providers
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;
    using MyMail.Domains.Providers;

    public class SqlServerDataBase : ISqlServerDataBase
    {
        public SqlConnection GetSqlConnection() => new (Environment.GetEnvironmentVariable("CONNECTION_STRING"));

        public string GetQuery(string nameFile)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = typeof(SqlServerDataBase);
            var resourceName = $@"{type.Namespace}.SQL.{nameFile}.sql";
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new (stream);
            return reader.ReadToEnd();
        }
    }
}
