using System;
using Client.Entities;
using Client.Services;

namespace Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var restService = new RestService();
      //restService.GetAllPerson();
      //restService.GetPersonById(4);
      //var person3 = new Person { FirstName = "Console Test Is Modified Twice by vova777", LastName = "Client was Updated by Vova", CategoryId = 5};
      //restService.DeletePerson(person3);
      //restService.GetAllPerson();
      //restService.GetPersonById(24);
      //var testCreate = new Person() {FirstName = "Test", LastName = "Create Updated", CategoryId = 5};
      //restService.DeletePerson(testCreate);
      //restService.GetAllCategory();
      //restService.GetCategoryById(55);
      var categoryTest = new Category() {Name = "New Category from Client side was modified by vova"};
      //restService.UpdateCategory(categoryTest);
      //restService.DeleteCategory(categoryTest);
      //restService.GetAllPerson();
      var testUpdate = new Person() {FirstName = "Console", LastName = "Client is updated", CategoryId = 2};
      //restService.UpdatePerson(testUpdate);
      restService.DeletePerson(testUpdate);
      Console.ReadLine();
    }
  }
}
