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
      var person =await _personService.GetByIdAsync(id);
      return Ok(person);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Person person)
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

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]Person person)
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

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
       await _personService.DeleteAsync(id);
      return Ok();
    }
  }
}