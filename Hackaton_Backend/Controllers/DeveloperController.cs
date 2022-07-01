using Microsoft.AspNetCore.Mvc;
using Hackaton.Service;
using Hackaton.Models; 

namespace Hackaton.Controllers;
[ApiController]
[Route("developer")]

public class DeveloperController:ControllerBase
{
    private DeveloperService developerService= new DeveloperService();
    [HttpGet]
    public IEnumerable<Developer> GetDeveloper()
    {
        return developerService.GetDeveloper();
    }
  
    [HttpGet("{id}")]

    public Developer GetDeveloper(int id)
    {
        return developerService.GetDeveloper(id);
    }

    [HttpPost]

    public IActionResult Create(Developer developer)
    {
        var created = developerService.Create(developer);
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

    public IActionResult Update(Developer developer)
    {
        var updated= developerService.Update(developer);
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
        var deleted = developerService.Delete(id);
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


