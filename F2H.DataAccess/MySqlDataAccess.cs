using System;
using System.Collections.Generic;
using System.Data;
using F2H.Interfaces;
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

        public MySqlDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public DataTable GetData(string sql, Dictionary<string, object> parameters)
        {
            using (var command = new MySqlCommand(sql, Connection))
            {
                AddParameters(command, parameters);

                var result = new DataTable();
                using (var dataAdapter = new MySqlDataAdapter(command))
                    dataAdapter.Fill(result);

                return result;
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
