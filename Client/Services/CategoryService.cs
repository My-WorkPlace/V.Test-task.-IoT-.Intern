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
    void Delete(int categoryId);
  }

  public class CategoryService:ICategoryService
  {
    private readonly string _url = "http://localhost:4000/category/";
    private readonly IRestClient _client;
    public List<Category> CategoryData { get;}
    public CategoryService()
    {
      _client = new RestClient(_url);
      CategoryData = new List<Category>();
      UpdateCategoryData();
    }

    private void UpdateCategoryData(IEnumerable<Category> data)
    {
      CategoryData.Clear();
      CategoryData.AddRange(data);
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
      UpdateCategoryData(responseData);
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
      UpdateCategoryData();
      ResponseDataDescription(response, responseData);
    }

    public void Update(Category category)
    {
      var request = new RestRequest(_url) { Method = Method.PUT, RequestFormat = DataFormat.Json };
      var bodyObj = CategoryData.Find(p => p.Id ==category.Id);//TODO not sure
      bodyObj.Name = category.Name;
      request.AddJsonBody(bodyObj);
      var response = _client.Put(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      UpdateCategoryData();
      ResponseDataDescription(response, responseData);
    }

    public void Delete(int categoryId)
    {
      var request = new RestRequest(_url+categoryId) { Method = Method.DELETE, RequestFormat = DataFormat.Json };
      var response = _client.Delete(request);
      var responseData = JsonConvert.DeserializeObject<Category>(response.Content);
      UpdateCategoryData();
      ResponseDataDescription(response, responseData);
    }

    private void RequsetTemplate<T>(IRestRequest request,Method methodType,T body)
    {
      //TODO create generic method 
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
