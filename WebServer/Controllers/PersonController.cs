using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Entities;
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
    public async Task<IActionResult> GetById(int id)
    {
      var person = await _personService.GetByIdAsync(id);
      return person == null ? (IActionResult)NotFound() : Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Person person)
    {
      await _personService.CreateAsync(person);
      return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Person person)
    {
      await _personService.UpdateAsync(person);
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _personService.DeleteAsync(id);
      return NoContent();
    }
  }
}