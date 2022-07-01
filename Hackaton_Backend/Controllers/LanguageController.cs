using Microsoft.AspNetCore.Mvc;
using Hackaton.Service;
using Hackaton.Models; 

namespace Hackaton.Controllers;
[ApiController]
[Route("language")]

public class LanguageController:ControllerBase
{
    private LanguageService languageService= new LanguageService();
    [HttpGet]
    public IEnumerable<Language> GetLanguage()
    {
        return languageService.GetLanguage();
    }

    [HttpGet("{id}")]

    public Language GetLanguage(int id)
    {
        return languageService.GetLanguage(id);
    }

    [HttpPost]

    public IActionResult Create(Language language)
    {
        var created = languageService.Create(language);
        if(created)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }


    [HttpPut]

    public IActionResult Update(Language language)
    {
        var updated= languageService.Update(language);
        if (updated)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        var deleted = languageService.Delete(id);
        if (deleted)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

}


