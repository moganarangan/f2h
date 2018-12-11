namespace F2H.Models.Configuration
{
    public class AppSettings
    {
        public string F2hSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Test { get; set; }
        public DBConnection MySqlConnection { get; set; }
    }

    public class DBConnection
    {
        public string DefaultConnection { get; set; }
        public int CommandTimeOut { get; set; }
    }
}
