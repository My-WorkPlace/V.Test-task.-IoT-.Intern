using System;

namespace WebServer.Entities
{
  public class Person:ICloneable
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CategoryId { get; set; } 
    public Category Category { get; set; }

    public object Clone()
    {
      return new Person()
      {
        Id = this.Id,
        FirstName = this.FirstName,
        LastName = this.LastName,
        CategoryId = this.CategoryId,
      };
    }
  }
}
