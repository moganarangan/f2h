namespace f2h.webapi.Helpers
{
    public class AppSettings
    {
        public string F2hSecret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Test { get; set; }
        public DBConnection ConnectionStrings { get; set; }
    }

    public class DBConnection
    {
        public string DefaultConnection { get; set; }
    }
}
