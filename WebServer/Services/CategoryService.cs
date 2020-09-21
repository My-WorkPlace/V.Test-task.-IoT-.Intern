using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Entities;
using WebServer.Helpers;

namespace WebServer.Services
{
  public interface ICategoryService
  {
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> CreateAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<int> DeleteAsync(int categoryId);
  }
  public class CategoryService:ICategoryService
  {
    private readonly DataContext _dataContext;
    public CategoryService(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    public async Task<Category> GetByIdAsync(int id) => await _dataContext.Categories.FindAsync(id);

    public async Task<IEnumerable<Category>> GetAllAsync() => await _dataContext.Categories.ToListAsync();

    public async Task<Category> CreateAsync(Category category)
    {
      await _dataContext.Categories.AddAsync(category);
      await _dataContext.SaveChangesAsync();
      return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
      var tmp = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
      if (tmp == null)
      {
        await _dataContext.Categories.AddAsync(category);
        await _dataContext.SaveChangesAsync();
        return category;
      }
      tmp.Name = category.Name;
      _dataContext.Categories.Update(tmp);
      await _dataContext.SaveChangesAsync();
      return tmp;
    }

    public async Task<int> DeleteAsync(int categoryId)
    {
      var deleteCategory = await _dataContext.Categories.Include(p => p.Persons).FirstAsync(c => c.Id == categoryId);
      if (deleteCategory.Persons.Any()) throw new Exception();
      _dataContext.Categories.Remove(deleteCategory);
      await _dataContext.SaveChangesAsync();
      return categoryId;
    }
  }
}
