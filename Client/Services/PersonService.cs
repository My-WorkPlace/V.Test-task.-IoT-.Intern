using System;
using System.Collections.Generic;
using System.Net;
using Client.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Client.Services
{
  public interface IPersonService
  {
    void GetAll();
    void GetById(int id);
    void Create(Person person);
    void Update(Person person);
    void Delete(Person person);
  }

  public class PersonService : IPersonService
  {
    private readonly string _url = "http://localhost:4000/person/";
    private readonly IRestClient _client;

    public PersonService()
    {
      _client = new RestClient(_url);
    }

    public void GetAll()
    {
      var request = new RestRequest(_url);
      var response = _client.Get<List<Person>>(request);
      var responseData = JsonConvert.DeserializeObject<List<Person>>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void GetById(int id)
    {
      var request = new RestRequest(_url + id);
      var response = _client.Get<Person>(request);
      var responseData = JsonConvert.DeserializeObject<Person>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Create(Person person)
    {
      var request = new RestRequest(_url) {Method = Method.POST, RequestFormat = DataFormat.Json};
      request.AddJsonBody(person);
      var response = _client.Post(request);
      var responseData = JsonConvert.DeserializeObject<Person>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Update(Person person)
    {
      var request = new RestRequest(_url){Method = Method.PUT, RequestFormat = DataFormat.Json};
      request.AddJsonBody(person);
      var response = _client.Put(request);
      var responseData = JsonConvert.DeserializeObject<Person>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Delete(Person person)
    {
      var request = new RestRequest(_url) {Method = Method.DELETE, RequestFormat = DataFormat.Json};
      request.AddJsonBody(person);
      var response = _client.Delete(request);
      var responseData = JsonConvert.DeserializeObject<Person>(response.Content);
      ResponseDataDescription(response,responseData);
    }

    private void ResponseDataDescription(IRestResponse response, Person responseData)
    {
      if (!response.IsSuccessful)
      {
        BadResponse(response);
      }
      else
      {
        SuccessfulResponse(response, responseData);
      }
    }
    private void ResponseDataDescription(IRestResponse response, IEnumerable<Person> responseData)
    {
      if (!response.IsSuccessful)
      {
        BadResponse(response);
      }
      else
      {
        SuccessfulResponse(response, responseData);
      }
    }
    private void BadResponse(IRestResponse response)
    {
      Console.WriteLine($"Status code :{response.StatusCode}");
      Console.WriteLine($"Error  message:{response.ErrorMessage}");
    }
    private void SuccessfulResponse(IRestResponse response, IEnumerable<Person> data)
    {
      Console.WriteLine($"Status code :{response.StatusCode}");
      Console.WriteLine("All Persons");
      foreach (var obj in data)
      {
        Console.WriteLine($"First name :{obj.FirstName}");
        Console.WriteLine($"Last name :{obj.LastName}");
        Console.WriteLine($"Category :{obj.Category.Name}");
        Console.WriteLine("--------------------------");
      }
    }
    private void SuccessfulResponse(IRestResponse response, Person data)
    {
      if (response.StatusCode == HttpStatusCode.OK && data == null)
      {
        Console.WriteLine($"Status code :{response.StatusCode}");
      }
      else
      {
        Console.WriteLine("Persons");
        Console.WriteLine($"First name :{data.FirstName}");
        Console.WriteLine($"Last name :{data.LastName}");
        Console.WriteLine($"Category :{data.Category.Name}");
        Console.WriteLine("--------------------------");
      }
    }
  }
}
