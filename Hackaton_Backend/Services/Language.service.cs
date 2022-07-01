using Hackaton.Repositores;
using Hackaton.Models;
using System.Security.Cryptography;
using System.Text;

namespace Hackaton.Service;

public class LanguageService
{
    private LanguageRepository languageRepository = new LanguageRepository();

    public IEnumerable<Language> GetLanguage()
    {
        return languageRepository.GetLanguage();
    }

    public Language GetLanguage(int id)
    {
        return languageRepository.GetLanguage(id);
    }

    public bool Create(Language language)
    {
        if (languageRepository.GetLanguage(language.Id)==null)
        {
            return languageRepository.Create(language);
        }
        else
        {
            return false;
        }
    }

    public bool Update(Language language)
    {
        return languageRepository.Update(language);
    }

    public bool Delete(int id)
    {
        return languageRepository.Delete(id);
    }

    public string HashPassword(string plainText)
    {
        var byteArray= ASCIIEncoding.ASCII.GetBytes(plainText);
        byte[] mySHA256=SHA256.Create().ComputeHash(byteArray);
        return Convert.ToBase64String(mySHA256);
    }


}