namespace TodoList.Models.Entites;

public sealed class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
     
    public int UserId { get; set; } //соединение с ключом User

    public required User User { get; set; } //ссылка на класс User

    public IEnumerable<Todo> Todoes { get; set; } = Enumerable.Empty<Todo>();

}
































//public class Moto
//{
//    public Moto()
//    {
//        var a = new Category() {peremen = new User()};
//    }
//}

