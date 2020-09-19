namespace WebServer.Entities
{
  public class Person
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CategoryId { get; set; } 
    public Category Category { get; set; }
  }
}
