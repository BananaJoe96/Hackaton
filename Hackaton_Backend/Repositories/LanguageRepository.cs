using Hackaton.Context;
using MySql.Data.MySqlClient;
using Hackaton.Models;


namespace Hackaton.Repositores;


public class LanguageRepository
{
    private AppDb appDb= new AppDb();

    public IEnumerable<Language> GetLanguage()
    {
        var result= new List<Language>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="select * from language";
        var reader=command.ExecuteReader();

        while (reader.Read())
        {
            var language = new Language()
            {
                Id= reader.GetInt16("id"),
                Name=reader.GetString("name")

            };
            result.Add(language);
        }
        appDb.Connection.Close();
        return result;
    }

    public Language GetLanguage(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="select * from language where id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName="id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var language = new Language()
            {
                Id= reader.GetInt16("id"),
                Name=reader.GetString("name")
                
            };
            appDb.Connection.Close();
            return language;
        }
        appDb.Connection.Close();
        return null;
    
    }


    public bool Create(Language language)
    {
        appDb.Connection.Open();
        var command =appDb.Connection.CreateCommand();
        command.CommandText="insert into language (name) values(@name)";
        var parameterName = new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value=language.Name
        };
        command.Parameters.Add(parameterName);
        var result =Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Language language)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="update language set name=@name";
        var parameterId= new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=language.Id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value=language.Name
        };
        command.Parameters.Add(parameterName);
        var result =Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }
    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText="delete from language where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=id
        };
        command.Parameters.Add(parameterId);
        var result=Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }
}