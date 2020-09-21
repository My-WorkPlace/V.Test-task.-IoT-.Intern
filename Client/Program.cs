using System;
using System.Collections.Generic;
using System.Linq;
using Client.Entities;
using Client.Services;

namespace Client
{
  class Program
  {
    static void Main(string[] args)
    {
      
      Run();
      Console.ReadLine();
    }

    private static void Run()
    {
      var personService = new PersonService();
      var categoryService = new CategoryService();
      List<Category> categories = new List<Category>()
      {
        new Category()
        {
          Name = "Category Test one"
        },
        new Category()
        {
          Name = "Category Test two"
        },new Category()
        {
          Name = "Category Test tree"
        }
      };
      categoryService.Create(categories[0]);
      categoryService.Create(categories[1]);
      categoryService.Create(categories[2]);
      categoryService.GetAll();
      List<Person> persons = new List<Person>()
      {
        new Person()
        {
          FirstName = "User",
          LastName = "One",
          CategoryId = 1
        },
        new Person()
        {
          FirstName = "User",
          LastName = "Two",
          CategoryId = 2
        },
        new Person()
        {
          FirstName = "User",
          LastName = "Tree",
          CategoryId = 3
        }
      };
      personService.Create(persons[0]);
      personService.Create(persons[1]);
      personService.Create(persons[2]);
      personService.GetAll();
      var updatedPerson = personService.PersonsData.First();
      updatedPerson.CategoryId = 2;
      updatedPerson.FirstName = "User was updated";
      personService.Update(updatedPerson);
      personService.GetById(updatedPerson.Id);
      var updatedCategory = categoryService.CategoryData.First();
      updatedCategory.Name = "Category was updated";
      categoryService.Update(updatedCategory);
      var categoryId = categoryService.CategoryData.First().Id;
      categoryService.GetById(categoryId);
      categoryService.Delete(categoryId);
      personService.Delete(updatedPerson.Id);
      personService.GetAll();
      categoryService.GetAll();
    }
  }
}
