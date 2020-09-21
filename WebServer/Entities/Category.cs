using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Entities
{
  public class Category
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public IEnumerable<Person> Persons { get; set; }  
  }
}
