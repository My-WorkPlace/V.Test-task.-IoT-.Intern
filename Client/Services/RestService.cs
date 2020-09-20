using Client.Entities;

namespace Client.Services
{
  public class RestService
  {
    private readonly IPersonService _personService;
    private readonly ICategoryService _categoryService;
    public RestService()
    {
      _personService = new PersonService();
      _categoryService = new CategoryService();
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

    public void GetAllCategory()
    {
      _categoryService.GetAll();
    }

    public void GetCategoryById(int id)
    {
      _categoryService.GetById(id);
    }

    public void CreateCategory(Category category)
    {
      _categoryService.Create(category);
    }

    public void UpdateCategory(Category category)
    {
      _categoryService.Update(category);
    }

    public void DeleteCategory(Category category)
    {
      _categoryService.Delete(category);
    }
  }
}
