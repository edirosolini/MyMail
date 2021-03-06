// <copyright file="ISqlServerDataBase.cs" company="El Roso">
// Copyright (c) El Roso. All rights reserved.
// </copyright>

namespace MyMail.Domains.Providers
{
    using System.Data.SqlClient;

    public interface ISqlServerDataBase
    {
        SqlConnection GetSqlConnection();

        string GetQuery(string nameFile);
    }
}
