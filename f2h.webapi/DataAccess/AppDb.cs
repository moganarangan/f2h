using MySql.Data.MySqlClient;
using System;

namespace F2H.MySqlConnector
{
    public class AppDb : IDisposable
    {
        public MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection("Server=localhost;Port=3306;Database=f2h;UserId=f2h;Password=1234");
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}