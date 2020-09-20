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
      var person3 = new Person { FirstName = "Console Test If method", LastName = "Client", CategoryId = 2};
      restService.CreatePerson(person3);
      Console.ReadLine();
    }
  }
}
