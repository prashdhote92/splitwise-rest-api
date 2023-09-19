namespace Splitwise;


public class AppSettings
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
    public DbConnection DbConnection { get; set; }

    public string DbConnectionString =>
        $"Host={DbConnection.Host}; Database={DbConnection.DbName}; Port={DbConnection.Port}; Username={DbConnection.UserName}; Password={DbConnection.Password}";
}
public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public string Default { get; set; }
}

public class DbConnection
{
    public string Host { get; set; }
    public string DbName { get; set; }
    public string Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}