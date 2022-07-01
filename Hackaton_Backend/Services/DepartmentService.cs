using Hackaton.Repositores;
using Hackaton.Models;
using System.Security.Cryptography;
using System.Text;

namespace Hackaton.Service;

public class DepartmentService
{
    private DepartmentRepository departmentRepository = new DepartmentRepository();

    public IEnumerable<Department> GetDepartment()
    {
        return departmentRepository.GetDepartment();
    }

    public Department GetDepartment(int id)
    {
        return departmentRepository.GetDepartment(id);
    }

    public bool Create(Department department)
    {
        if (departmentRepository.GetDepartment(department.Id)==null)
        {
            return departmentRepository.Create(department);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Department department)
    {
        return departmentRepository.Update(department);
    }

    public bool Delete(int id)
    {
        return departmentRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray= ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256=SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }


}