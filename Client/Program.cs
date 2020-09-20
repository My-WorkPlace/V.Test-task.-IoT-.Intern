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
      var testCreate = new Person() {FirstName = "Test", LastName = "Create Updated", CategoryId = 5};
      restService.DeletePerson(testCreate);
      Console.ReadLine();
    }
  }
}
