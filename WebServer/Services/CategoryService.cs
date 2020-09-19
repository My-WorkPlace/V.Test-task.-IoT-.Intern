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
    Task<int> DeleteAsync(int id);
  }
  public class CategoryService:ICategoryService
  {
    private readonly DataContext _dataContext;
    public CategoryService(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    public async Task<Category> GetByIdAsync(int id) => await _dataContext.Categories.FindAsync(id);

    public async Task<IEnumerable<Category>> GetAllAsync() => await _dataContext.Categories.Include(p=>p.Persons).ToListAsync();

    public async Task<Category> CreateAsync(Category category)
    {
      await _dataContext.Categories.AddAsync(category);
      await _dataContext.SaveChangesAsync();
      return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
      _dataContext.Categories.Update(category);
      await _dataContext.SaveChangesAsync();
      return category;
    }

    public async Task<int> DeleteAsync(int id)
    {
      var deleteCategory =await _dataContext.Categories.Include(p => p.Persons).FirstAsync(c => c.Id == id);
      if (deleteCategory == null) return id;
      _dataContext.Categories.Remove(deleteCategory);
      await _dataContext.SaveChangesAsync();
      return id;
    }
  }
}
