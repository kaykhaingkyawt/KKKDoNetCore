﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKKDoNetCore.ConsoleApp.Services;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "KKKDoNetCore",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true,
    };
}
