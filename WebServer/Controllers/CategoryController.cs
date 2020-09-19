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
      var category =await _categoryService.GetByIdAsync(id);
      return Ok(category);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
      try
      {
        await _categoryService.CreateAsync(category);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody]Category category)
    {
      try
      {
        await _categoryService.UpdateAsync(category);
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
      await _categoryService.DeleteAsync(id);
      return Ok();
    }
  }
}