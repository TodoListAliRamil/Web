using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Services;

public interface ITodoService
{
    void Add(Todo todo);
    void Edit(Todo todo);
    void Delete(int id);
    Todo Get(int id); //получение
}
