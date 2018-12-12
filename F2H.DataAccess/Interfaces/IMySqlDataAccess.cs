using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace F2H.DataAccess.Interfaces
{
    public interface IMySqlDataAccess : IDisposable
    {
        MySqlConnection Connection { get; }
        MySqlTransaction Transaction { get; set; }
        int CommandTimeOut { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        DataTable GetData(string query, Dictionary<string, object> parameters);
        DataTable GetData(string query, string tableName, Dictionary<string, object> parameters);
        DataSet GetDataset(string query, Dictionary<string, object> parameters);
        DataSet GetDataFromStoredProcedure(string procedureName, Dictionary<string, object> parameters);
        void ExecuteNonQuery(string query, Dictionary<string, object> parameters);
        void ExecuteNonQueryFromStoredProcedure(string procedureName, Dictionary<string, object> parameters);
    }
}
