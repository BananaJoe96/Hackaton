using Hackaton.Context;
using MySql.Data.MySqlClient;
using Hackaton.Models;

namespace Hackaton.Repositores;

public class DeveloperRepository
{
    private AppDb appDb = new AppDb();

    public IEnumerable<Developer> GetDeveloper()
    {
        var result = new List<Developer>();

        appDb.Connection.Open();
        var command= appDb.Connection.CreateCommand();
        command.CommandText= "select * from developer";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var developer=new Developer()
            {
                Id =reader.GetInt16("id"),
                Name=reader.GetString("name"),
                Surname=reader.GetString("surname"),
                Email=reader.GetString("email"),
                Password=reader.GetString("password"),
                Age=reader.GetInt16("age"),
                Qualification=reader.GetString("qualification"),
                PreferredLanguage=reader.GetString("preferredlanguage"),
                Id_Language=reader.GetInt16("id_language")
            };
            result.Add(developer);
        }
        appDb.Connection.Close();

        return result;

    }

    public Developer GetDeveloper(int? id)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText="select * from developer where id=@id";
        var parameter= new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            var developer = new Developer()
            {
                Id =reader.GetInt16("id"),
                Name=reader.GetString("name"),
                Surname=reader.GetString("surname"),
                Email=reader.GetString("email"),
                Password=reader.GetString("password"),
                Age=reader.GetInt16("age"),
                Qualification=reader.GetString("qualification"),
                PreferredLanguage=reader.GetString("preferredlanguage"),
                Id_Language=reader.GetInt16("id_language")
            };
            appDb.Connection.Close();
            return developer;
        }
        appDb.Connection.Close();
        return null;
    }

    public bool Create(Developer developer)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText="insert into developer (name,surname,email,password,age,qualification,preferredlanguage,id_language) values (@name,@surname,@email,@password,@age,@qualification,@preferredlanguage,@id_language)";
        var parameterName= new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value = developer.Name
        };
        command.Parameters.Add(parameterName);
        var parameterSurname= new MySqlParameter()
        {
            ParameterName="surname",
            DbType=System.Data.DbType.String,
            Value = developer.Surname
        };
        command.Parameters.Add(parameterSurname);
        var parameterEmail= new MySqlParameter()
        {
            ParameterName="email",
            DbType=System.Data.DbType.String,
            Value = developer.Email
        };
        command.Parameters.Add(parameterEmail);
        var parameterPassword= new MySqlParameter()
        {
            ParameterName="password",
            DbType=System.Data.DbType.String,
            Value = developer.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterAge= new MySqlParameter()
        {
            ParameterName="age",
            DbType=System.Data.DbType.Int16,
            Value = developer.Age
        };
        command.Parameters.Add(parameterAge);
        var parameterQualification= new MySqlParameter()
        {
            ParameterName="qualification",
            DbType=System.Data.DbType.String,
            Value = developer.Qualification
        };
        command.Parameters.Add(parameterQualification);
        var parameterPreferredLanguage= new MySqlParameter()
        {
            ParameterName="preferredlanguage",
            DbType=System.Data.DbType.String,
            Value = developer.PreferredLanguage
        };
        command.Parameters.Add(parameterPreferredLanguage);
        var parameterId_Language= new MySqlParameter()
        {
            ParameterName="id_language",
            DbType=System.Data.DbType.Int16,
            Value = developer.Id_Language
        };
        command.Parameters.Add(parameterId_Language);

        var result= Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;

    }

    public bool Update(Developer developer)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText= "update developer set name=@name,surname=@surname,email=@email,password=@password,age=@age,qualification=@qualification,preferredlanguage=@preferredlanguage,id_language=@id_language where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=developer.Id
        };
        var parameterName= new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value = developer.Name
        };
        command.Parameters.Add(parameterName);
        var parameterSurname= new MySqlParameter()
        {
            ParameterName="surname",
            DbType=System.Data.DbType.String,
            Value = developer.Surname
        };
        command.Parameters.Add(parameterSurname);
        var parameterEmail= new MySqlParameter()
        {
            ParameterName="email",
            DbType=System.Data.DbType.String,
            Value = developer.Email
        };
        command.Parameters.Add(parameterEmail);
        var parameterPassword= new MySqlParameter()
        {
            ParameterName="password",
            DbType=System.Data.DbType.String,
            Value = developer.Password
        };
        command.Parameters.Add(parameterPassword);
        var parameterAge= new MySqlParameter()
        {
            ParameterName="age",
            DbType=System.Data.DbType.Int16,
            Value = developer.Age
        };
        command.Parameters.Add(parameterAge);
        var parameterQualification= new MySqlParameter()
        {
            ParameterName="qualification",
            DbType=System.Data.DbType.String,
            Value = developer.Qualification
        };
        command.Parameters.Add(parameterQualification);
        var parameterPreferredLanguage= new MySqlParameter()
        {
            ParameterName="preferredlanguage",
            DbType=System.Data.DbType.String,
            Value = developer.PreferredLanguage
        };
        command.Parameters.Add(parameterPreferredLanguage);
        var parameterId_Language= new MySqlParameter()
        {
            ParameterName="id_language",
            DbType=System.Data.DbType.Int16,
            Value = developer.Id_Language
        };
        command.Parameters.Add(parameterId_Language);

        var result=Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText="delete from developer where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=id
        };
        command.Parameters.Add(parameterId);
        var result= Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }



}