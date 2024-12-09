using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Repositories;

public interface ITodoRepository
{
    void Add(Todo todo);
    void Update(Todo todo);
    void Delete(int id);
    Todo? Get(int id); //получение
}
