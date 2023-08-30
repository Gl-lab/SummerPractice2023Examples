namespace Domain.Entity;
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public List<Post> Posts { get; set; }
}
