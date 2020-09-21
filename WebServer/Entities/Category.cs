using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Entities
{
  public class Category
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Can't be null'")]
    public string Name { get; set; }

    public IEnumerable<Person> Persons { get; set; }  
  }
}
