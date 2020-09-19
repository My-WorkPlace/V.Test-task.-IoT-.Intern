using System;
using System.Collections.Generic;
using Client.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Client.Services
{
  public class RestService
  {
    private readonly string _url = "http://localhost:4000/";
    private string _getPerson;
    private string _getCategory;
    private readonly IRestClient _client;
    private IRestRequest RestRequest { get; set; }
    public RestService()
    {
      _client = new RestClient(_url);
      ImplementationFields();
    }

    private void ImplementationFields()
    {
      _getPerson = "http://localhost:4000/person/";
      _getCategory = "http://localhost:4000/category/";
    }

    public void GetPerson()
    {
      RestRequest = new RestRequest(_getPerson);
      var response = _client.Get<List<Person>>(RestRequest);
      var responseData = JsonConvert.DeserializeObject<List<Person>>(response.Content);
      foreach (var person in responseData)
      {
        Console.WriteLine($" f name :{person.FirstName}");
        Console.WriteLine($" l name :{person.LastName}");
        Console.WriteLine($" category :{person.Category.Name}");
        Console.WriteLine("-------------------------");
      }
      if (!response.IsSuccessful)
      {
        BadResponse(response);
      }
      SuccessfulResponse(response);
    }

    private void BadResponse(IRestResponse response)
    {
      Console.WriteLine($"Status code :{response.StatusCode}");
      Console.WriteLine($"Error  message:{response.ErrorMessage}");
    }

    private void SuccessfulResponse(IRestResponse response)
    {
      Console.WriteLine($"Status code :{response.StatusCode}");
      Console.WriteLine($"Response content :{response.Content}");

      //foreach (var obj in data)
      //{
      //  Console.WriteLine($"First name :{obj.FirstName}");
      //  Console.WriteLine($"Last name :{obj.LastName}");
      //  //Console.WriteLine($"Category :{obj.Category.Name}");
      //  Console.WriteLine($"--------------------------");
      //}
    }
  }
}
