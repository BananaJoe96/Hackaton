using Hackaton.Context;
using MySql.Data.MySqlClient;
using Hackaton.Models;


namespace Hackaton.Repositores;


public class DepartmentRepository
{
    private AppDb appDb= new AppDb();

    public IEnumerable<Department> GetDepartment()
    {
        var result= new List<Department>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="select * from department";
        var reader=command.ExecuteReader();

        while (reader.Read())
        {
            var department = new Department()
            {
                Id= reader.GetInt16("id"),
                Name=reader.GetString("name"),
                Id_Developer=reader.GetInt16("id_developer")

            };
            result.Add(department);
        }
        appDb.Connection.Close();
        return result;
    }

    public Department GetDepartment(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="select * from department where id=@id";
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
            var department = new Department()
            {
                Id= reader.GetInt16("id"),
                Name=reader.GetString("name"),
                Id_Developer=reader.GetInt16("id_developer")
                
            };
            appDb.Connection.Close();
            return department;
        }
        appDb.Connection.Close();
        return null;
    
    }


    public bool Create(Department department)
    {
        appDb.Connection.Open();
        var command =appDb.Connection.CreateCommand();
        command.CommandText="insert into department (name,id_developer) values(@name,@id_developer)";
        var parameterName = new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value=department.Name
        };
        command.Parameters.Add(parameterName);
        var parameterId_Developer = new MySqlParameter()
        {
            ParameterName="id_developer",
            DbType=System.Data.DbType.Int16,
            Value=department.Id_Developer
        };
        command.Parameters.Add(parameterId_Developer);

        var result =Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Department department)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText="update department sete name=@name,id_developer=@id_developer";
        var parameterId= new MySqlParameter()
        {
            ParameterName="id",
            DbType=System.Data.DbType.Int16,
            Value=department.Id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName="name",
            DbType=System.Data.DbType.String,
            Value=department.Name
        };
        command.Parameters.Add(parameterName);
        var parameterId_Developer = new MySqlParameter()
        {
            ParameterName="id_developer",
            DbType=System.Data.DbType.Int16,
            Value=department.Id_Developer
        };
        command.Parameters.Add(parameterId_Developer);
        var result =Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }
    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command=appDb.Connection.CreateCommand();
        command.CommandText="delete from department where id=@id";
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