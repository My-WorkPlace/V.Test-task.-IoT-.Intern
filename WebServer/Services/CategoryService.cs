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
    IEnumerable<Category> GetAll();
    Category Create(Category category);
    void Update(Category category);
    void Delete(int id);
  }
  public class CategoryService:ICategoryService
  {
    private readonly DataContext _dataContext;
    public CategoryService(DataContext dataContext)
    {
      _dataContext = dataContext;
    }

    public async Task<Category> GetByIdAsync(int id) => await _dataContext.Categories.FindAsync(id);

    public IEnumerable<Category> GetAll() => _dataContext.Categories.Include(p=>p.Persons).ToList();

    public Category Create(Category category)
    {
      _dataContext.Categories.Add(category);
      _dataContext.SaveChanges();
      return category;
    }

    public void Update(Category category)
    {
      _dataContext.Categories.Update(category);
      _dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      var deleteCategory = _dataContext.Categories.Include(p => p.Persons).First(c => c.Id == id);
      if (deleteCategory == null) return;
      _dataContext.Categories.Remove(deleteCategory);
      _dataContext.SaveChanges();
    }
  }
}
