using System;
using System.Threading.Tasks;
using System.Xml.Linq;
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
      try
      {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null) throw new Exception(); 
        return Ok(category);
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
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

    [HttpPut]
    public async Task<IActionResult> Update(Category category)
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

    [HttpDelete]
    public async Task<IActionResult> MyDelete(Category category)
    {
      await _categoryService.MyDeleteAsync(category);
      return Ok();
    }
  }
}