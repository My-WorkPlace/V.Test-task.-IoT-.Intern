using System.Collections.Generic;

namespace WebServer.Entities
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Person> Persons { get; set; }  
  }
}
