using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace F2H.Interfaces
{
    public interface IMySqlDataAccess : IDisposable
    {
        MySqlConnection Connection { get; }

        DataTable GetData(string sql, Dictionary<string, object> parameters);

        // List<DataTable> GetDataTables(string sql, Dictionary<string, object> parameters);

        // DataSet GetDataFromStoredProcedure(string procedureName, Dictionary<string, object> parameters);

        // void ExecuteNonQuery(string sql, Dictionary<string, object> parameters);
    }
}
