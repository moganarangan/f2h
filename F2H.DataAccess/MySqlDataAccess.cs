using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using F2H.DataAccess.Interfaces;
using F2H.Models.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace F2H.DataAccess
{
    public class MySqlDataAccess : IMySqlDataAccess
    {
        private readonly AppSettings _appSettings;

        public MySqlConnection Connection
        {
            get { return new MySqlConnection(_appSettings.MySqlConnection.DefaultConnection); }
        }

        public MySqlTransaction Transaction { get; set; }

        public int CommandTimeOut
        {
            get { return _appSettings.MySqlConnection.CommandTimeOut; }
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
        }

        public MySqlDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public DataTable GetData(string query, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                AddParameters(command, parameters);

                var result = new DataTable();
                using (var dataAdapter = new MySqlDataAdapter(command))
                    dataAdapter.Fill(result);

                return result;
            }
        }

        public DataTable GetData(string query, string tableName, Dictionary<string, object> parameters)
        {
            var dt = GetData(query, parameters);
            dt.TableName = tableName;

            return dt;
        }

        public DataSet GetDataset(string query, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                AddParameters(command, parameters);

                var results = new DataSet();
                using (var dataAdapter = new MySqlDataAdapter(command))
                    dataAdapter.Fill(results);

                return results;
            }
        }

        public DataSet GetDataFromStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(procedureName, Connection, Transaction))
            {
                command.CommandType = CommandType.StoredProcedure;
                AddParameters(command, parameters);

                using (var adapter = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    adapter.Fill(data);
                    return data;
                }
            }
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                command.Connection.Open();
                command.CommandTimeout = CommandTimeOut;

                AddParameters(command, parameters);

                var result = command.ExecuteScalar();

                return result;
            }
        }

        public async Task<object> ExecuteScalarAsync(string query, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                command.Connection.Open();
                command.CommandTimeout = CommandTimeOut;

                AddParameters(command, parameters);

                var result = await command.ExecuteScalarAsync();

                return result;
            }
        }

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            ExecuteNonQuery(query, parameters, CommandType.Text);
        }

        public void ExecuteNonQueryFromStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            ExecuteNonQuery(procedureName, parameters, CommandType.StoredProcedure);
        }

        private void ExecuteNonQuery(string query, Dictionary<string, object> parameters, CommandType commandType)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                command.Connection.Open();
                command.CommandTimeout = CommandTimeOut;
                command.CommandType = commandType;

                AddParameters(command, parameters);

                command.ExecuteNonQuery();
            }
        }

        public async Task ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters)
        {
            await ExecuteNonQueryAsync(query, parameters, CommandType.Text);
        }

        public async Task ExecuteNonQueryFromStoredProcedureAsync(string procedureName, Dictionary<string, object> parameters)
        {
            await ExecuteNonQueryAsync(procedureName, parameters, CommandType.StoredProcedure);
        }

        private async Task ExecuteNonQueryAsync(string query, Dictionary<string, object> parameters, CommandType commandType)
        {
            using (var command = new MySqlCommand(query, Connection, Transaction))
            {
                command.Connection.Open();
                command.CommandTimeout = CommandTimeOut;
                command.CommandType = commandType;

                AddParameters(command, parameters);

                await command.ExecuteNonQueryAsync();
            }
        }

        private static void AddParameters(MySqlCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;

            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? DBNull.Value);
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
