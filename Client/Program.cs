using System;
using Client.Services;

namespace Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var restService = new RestService();
      restService.GetPerson();
      Console.ReadLine();
    }
  }
}
