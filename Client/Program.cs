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
      var personService = new PersonService();
      //var categoryService = new CategoryService();
      List<Category> categories = new List<Category>()
     {
       new Category()
       {
         Name = "Category one"
       },
       new Category()
       {
         Name = "Category two"
       },new Category()
       {
         Name = "Category tree"
       }
     };

      //categoryService.Create(categories[0]);
      //categoryService.Create(categories[1]);
      //categoryService.Create(categories[2]);
      //categoryService.GetAll();

      //var categoryData = categoryService.CategoryData.First();
      //categoryService.GetById(categoryData.Id);
      //categoryService.GetById(45);TODO add validation

      //var tmp = categoryService.CategoryData.First();
      //tmp.Name = "Category was updated";
      //categoryService.Update(tmp);

      //var deletedCategory = new Category() {Name = "deleted category"};
      //categoryService.Create(deletedCategory);
      //categoryService.Delete(categoryService.CategoryData.First(n => n.Name == deletedCategory.Name).Id);
      //categoryService.Delete(4);

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

      //personService.Create(persons[0]);
      //personService.Create(persons[1]);
      //personService.Create(persons[2]);
      //personService.GetAll();
      //personService.GetById(1);

      //var tmp = personService.PersonsData.First();
      //tmp.CategoryId = 2;
      //tmp.FirstName = "User was updated";
      //personService.Update(tmp);
      var delPerson = personService.PersonsData.First();
      personService.Delete(delPerson.Id);
      Console.ReadLine();
    }
  }
}
