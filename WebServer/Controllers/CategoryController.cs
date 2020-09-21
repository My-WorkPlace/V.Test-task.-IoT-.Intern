using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Entities;
using WebServer.Services;

namespace WebServer.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var categories = await _categoryService.GetAllAsync();
      return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var category = await _categoryService.GetByIdAsync(id);
      return category == null ? (IActionResult)NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
      await _categoryService.CreateAsync(category);
      return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Category category)
    {
      var res = await _categoryService.UpdateAsync(category);
      return res == null ? (IActionResult)NotFound() : Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _categoryService.DeleteAsync(id);
      return NoContent();
    }
  }
}