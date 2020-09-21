using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Entities;
using WebServer.Helpers;
using WebServer.Services;

namespace WebServer.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PersonController : ControllerBase
  {
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
      _personService = personService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var persons = await _personService.GetAllAsync();
      return Ok(persons);
    }

    [HttpGet("{id}")]
    public async  Task<IActionResult> GetById(int id)
    {
      try
      {
        var person = await _personService.GetByIdAsync(id);
        return Ok(person);
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
      try
      {
        await _personService.CreateAsync(person);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Person person)
    {
      try
      {
        await _personService.UpdateAsync(person);
        return Ok();
      }
      catch (AppException ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        await _personService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }

    }
  }
}