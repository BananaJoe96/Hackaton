using Hackaton.Repositores;
using Hackaton.Models;
using System.Security.Cryptography;
using System.Text;

namespace Hackaton.Service;

public class DeveloperService
{
    private DeveloperRepository developerRepository = new DeveloperRepository();

    public IEnumerable<Developer> GetDeveloper()
    {
        return developerRepository.GetDeveloper();
    }

    public Developer GetDeveloper(int id)
    {
        return developerRepository.GetDeveloper(id);
    }

    public bool Create(Developer developer)
    {
        if (developerRepository.GetDeveloper(developer.Id)==null)
        {
            return developerRepository.Create(developer);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Developer developer)
    {
        return developerRepository.Update(developer);
    }

    public bool Delete(int id)
    {
        return developerRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray= ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256=SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }

}