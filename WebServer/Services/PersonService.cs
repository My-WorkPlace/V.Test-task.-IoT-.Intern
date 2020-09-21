using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public PersonService(DataContext dataContext)
    {
      _dataContext = dataContext;
    }
    public async Task<Person> GetByIdAsync(int id) => await _dataContext.Persons.FindAsync(id);

    public async Task<IEnumerable<Person>> GetAllAsync() => await _dataContext.Persons.ToListAsync();

    public async Task<Person> CreateAsync(Person person)
    {
      await _dataContext.Persons.AddAsync(person);
      await _dataContext.SaveChangesAsync();
      return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
      var tmp = await _dataContext.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);
      if (tmp != null)
      {
        tmp.FirstName = person.FirstName;
        tmp.LastName = person.LastName;
        tmp.CategoryId = person.CategoryId;

        _dataContext.Persons.Update(tmp);
        await _dataContext.SaveChangesAsync();
        return tmp;
      }
      return null;
    }
    
    public async Task<int> DeleteAsync(int id)
    {
      var deletePerson = await _dataContext.Persons.FirstOrDefaultAsync(x=>x.Id == id);
      if (deletePerson == null) return id;
      _dataContext.Persons.Remove(deletePerson);
      await _dataContext.SaveChangesAsync();
      return id;
    }
  }
}
