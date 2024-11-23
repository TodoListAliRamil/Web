namespace TodoList.Models.Entites;

public sealed class User
{
    public int Id { get; set; } 

    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();

}
