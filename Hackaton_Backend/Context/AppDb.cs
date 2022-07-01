using MySql.Data.MySqlClient;

namespace Hackaton.Context;

public class AppDb
{
    public MySqlConnection Connection {get;}

    private const string defaultConnectionString="server=localhost;database=app_hackaton;uid=root;pwd=password;";

    public AppDb()
    {
        Connection= new MySqlConnection(defaultConnectionString);
    }

    public AppDb(string ConnectionString)
    {
        Connection=new MySqlConnection(ConnectionString);
    }
}