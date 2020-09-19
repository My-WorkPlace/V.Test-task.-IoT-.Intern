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
    public IActionResult GetAll()
    {
      var categories = _categoryService.GetAll();
      return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var category =await _categoryService.GetByIdAsync(id);
      return Ok(category);
    }

    [HttpPost("create")]
    public IActionResult Create([FromBody] Category category)
    {
      try
      {
        _categoryService.Create(category);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody]Category category)
    {
      try
      {
        _categoryService.Update(category);
        return Ok();
      }
      catch (AppException ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPost("Delete/{id}")]
    public IActionResult Delete(int id)
    {
      _categoryService.Delete(id);
      return Ok();
    }
  }
}