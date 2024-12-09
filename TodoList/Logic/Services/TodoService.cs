using TodoList.Logic.Interfaces.Repositories;
using TodoList.Logic.Interfaces.Services;
using TodoList.Models.Entites;

namespace TodoList.Logic.Services;

public sealed class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public void Add(Todo todo)
    {
        _todoRepository.Add(todo);
    }

    public void Delete(int id)
    {
        _todoRepository.Delete(id);
    }

    public Todo Get(int id)
    {
        return _todoRepository.Get(id) ?? throw new ArgumentException($"По данному ID = {id} задача не найдена");
    }

    public void Edit(Todo todo)
    {
       _todoRepository.Update(todo);
    }
}
