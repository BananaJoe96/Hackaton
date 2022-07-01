using Microsoft.AspNetCore.Mvc;
using Hackaton.Service;
using Hackaton.Models; 

namespace Hackaton.Controllers;
[ApiController]
[Route("department")]

public class DepartmentController:ControllerBase
{
    private DepartmentService departmentService= new DepartmentService();
    [HttpGet]
    public IEnumerable<Department> GetDepartment()
    {
        return departmentService.GetDepartment();
    }

    [HttpGet("{id}")]

    public Department GetDepartment(int id)
    {
        return departmentService.GetDepartment(id);
    }

    [HttpPost]

    public IActionResult Create(Department department)
    {
        var created = departmentService.Create(department);
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

    public IActionResult Update(Department department)
    {
        var updated= departmentService.Update(department);
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
        var deleted = departmentService.Delete(id);
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


