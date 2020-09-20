using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Entities;
using WebServer.Helpers;

namespace WebServer.Services
{
  public interface IPersonService
  {
    Task<Person> GetByIdAsync(int id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> CreateAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<int> DeleteAsync(int id);
  }
  public class PersonService : IPersonService
  {
    private readonly DataContext _dataContext;
    private readonly ICategoryService _categoryService;
    public PersonService(DataContext dataContext, ICategoryService categoryService)
    {
      _dataContext = dataContext;
      _categoryService = categoryService;
    }
    public async Task<Person> GetByIdAsync(int id) => await _dataContext.Persons.Include(c => c.Category).FirstAsync(obj => obj.Id == id);

    public async Task<IEnumerable<Person>> GetAllAsync() => await _dataContext.Persons.Include(c => c.Category).ToListAsync();

    public async Task<Person> CreateAsync(Person person)
    {
      //person.Category = await _categoryService.GetByIdAsync(person.CategoryId);
      await _dataContext.Persons.AddAsync(person);
      await _dataContext.SaveChangesAsync();
      return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
      _dataContext.Persons.Update(person);
      await _dataContext.SaveChangesAsync();
      return person;
    }

    public async Task<int> DeleteAsync(int id)
    {
      var deletePerson = await _dataContext.Persons.FindAsync(id);
      if (deletePerson == null) return id;
      _dataContext.Persons.Remove(deletePerson);
      await _dataContext.SaveChangesAsync();
      return id;
    }
  }
}
