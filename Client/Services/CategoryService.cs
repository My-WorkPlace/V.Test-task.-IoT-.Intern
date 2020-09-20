using System;
using System.Collections.Generic;
using System.Net;
using Client.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace Client.Services
{
  public interface ICategoryService
  {
    void GetAll();
    void GetById(int id);
    void Create(Category category);
    void Update(Category category);
    void Delete(Category category);
  }

  public class CategoryService:ICategoryService
  {
    private readonly string _url = "http://localhost:4000/category/";
    private readonly IRestClient _client;
    private readonly List<Category> _categoryData;
    public CategoryService()
    {
      _client = new RestClient(_url);
      _categoryData = new List<Category>();
      UpdateCategoryData();
    }

    private void UpdateCategoryData(IEnumerable<Category> data)
    {
      _categoryData.Clear();
      _categoryData.AddRange(data);
    }
    private void UpdateCategoryData()
    {
      var request = new RestRequest(_url);
      var response = _client.Get<List<Category>>(request);
      var responseData = JsonConvert.DeserializeObject<List<Category>>(response.Content);
      UpdateCategoryData(responseData);
    }

    public void GetAll()
    {
      var request = new RestRequest(_url);
      var response = _client.Get<List<Category>>(request);
      var responseData = JsonConvert.DeserializeObject<List<Category>>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void GetById(int id)
    {
      var request = new RestRequest(_url + id);
      var response = _client.Get<Category>(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Create(Category category)
    {
      var request = new RestRequest(_url) { Method = Method.POST, RequestFormat = DataFormat.Json };
      request.AddJsonBody(category);
      var response = _client.Post(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Update(Category category)
    {
      var request = new RestRequest(_url) { Method = Method.PUT, RequestFormat = DataFormat.Json };
      request.AddJsonBody(category);
      var response = _client.Put(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    public void Delete(Category category)
    {
      var request = new RestRequest(_url) { Method = Method.DELETE, RequestFormat = DataFormat.Json };
      request.AddJsonBody(category);
      var response = _client.Delete(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      ResponseDataDescription(response, responseData);
    }

    private void RequsetTemplate(IRestRequest request,Method methodType,Object body)
    {
      //TODO create general method 
    }

    private void ResponseDataDescription(IRestResponse response, IEnumerable<Category> responseData)
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
    private void ResponseDataDescription(IRestResponse response, Category responseData)
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
    private void SuccessfulResponse(IRestResponse response, IEnumerable<Category> data)
    {
      Console.WriteLine($"Status code :{response.StatusCode}");
      Console.WriteLine("All Category");
      foreach (var obj in data)
      {
        Console.WriteLine($"Name :{obj.Name}");
        Console.WriteLine("--------------------------");
      }
    }
    private void SuccessfulResponse(IRestResponse response, Category data)
    {
      if (response.StatusCode == HttpStatusCode.OK && data == null)
      {
        Console.WriteLine($"Status code :{response.StatusCode}");
      }
      else
      {
        Console.WriteLine("Category");
        Console.WriteLine($"Name :{data.Name}");
        Console.WriteLine("--------------------------");
      }
    }
  }
}
