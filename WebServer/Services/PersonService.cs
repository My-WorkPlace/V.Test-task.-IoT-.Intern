using System.Collections.Generic;
using System.Linq;
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
    Task<Person> MyDeleteAsync(Person person);
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
      await _dataContext.Persons.AddAsync(person);
      await _dataContext.SaveChangesAsync();
      return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
      //var tmp = await _dataContext.Persons.Include(c => c.Category).FirstOrDefaultAsync(x => x.FirstName == person.FirstName || x.LastName == person.LastName);
      var tmp = await _dataContext.Persons.Include(c => c.Category).FirstOrDefaultAsync(x => x.Id == person.Id);
      if (tmp == null)
      {
        await _dataContext.Persons.AddAsync(person);
        await _dataContext.SaveChangesAsync();
        return person;
      }

      //tmp = (Person)person.Clone();
      tmp.FirstName = person.FirstName;
      tmp.LastName = person.LastName;
      tmp.CategoryId = person.CategoryId;

      _dataContext.Persons.Update(tmp);
      await _dataContext.SaveChangesAsync();
      return tmp;
    }

    public async Task<int> DeleteAsync(int id)
    {
      var deletePerson = await _dataContext.Persons.FindAsync(id);
      if (deletePerson == null) return id;
      _dataContext.Persons.Remove(deletePerson);
      await _dataContext.SaveChangesAsync();
      return id;
    }

    public async Task<Person> MyDeleteAsync(Person person)
    {
      var deletePerson = await _dataContext.Persons.FindAsync(person.Id);
      if (deletePerson == null) return person;
      _dataContext.Persons.Remove(deletePerson);
      await _dataContext.SaveChangesAsync();
      return deletePerson;
    }
  }
}
