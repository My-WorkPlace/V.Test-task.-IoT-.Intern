using System;
using Client.Entities;
using Client.Services;

namespace Client
{
  class Program
  {
    static void Main(string[] args)
    {
     var personService = new PersonService();
     var categoryService = new CategoryService();


    //var testUpdate = new Person() {FirstName = "Console", LastName = "Client is updated", CategoryId = 2};
    //restService.UpdatePerson(testUpdate);
    //
    Console.ReadLine();
    }
}
}
