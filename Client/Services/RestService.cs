using Client.Entities;

namespace Client.Services
{
  public class RestService
  {
    private readonly IPersonService _personService;
    public RestService()
    {
      _personService = new PersonService();
    }

    public void GetAllPerson()
    {
      _personService.GetAll();
    }

    public void GetPersonById(int id)
    {
      _personService.GetById(id);
    }

    public void CreatePerson(Person person)
    {
      _personService.Create(person);
    }

    public void UpdatePerson(Person person)
    {
      _personService.Update(person);
    }

    public void DeletePerson(Person person)
    {
      _personService.Delete(person);
    }
  }
}
