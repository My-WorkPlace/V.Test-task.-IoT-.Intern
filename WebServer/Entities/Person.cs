using System.ComponentModel.DataAnnotations;

namespace WebServer.Entities
{
  public class Person
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Can't be null")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Can't be null")]
    public string LastName { get; set; }

    public int CategoryId { get; set; } 
    public Category Category { get; set; }
  }
}
