using MySql.Data.MySqlClient;

namespace SaemWeb.Configs
{
  public class Connection
  {
    private readonly string _connectionString;
    public Connection(IConfiguration configuration)
    {
      _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
    }

    public MySqlConnection GetConnection()
    {
      var conn = new MySqlConnection(_connectionString);
      conn.Open();
      return conn;
    }

    public MySqlCommand CreateCommand(string query, MySqlConnection? conn = null)
    {
      conn ??= GetConnection();
      return new MySqlCommand(query, conn);
    }
  }
}