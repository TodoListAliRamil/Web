using Microsoft.EntityFrameworkCore;
using TodoList.Logic.Interfaces.Repositories;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Logic.Repositories
{
    public sealed class TodoRepository : ITodoRepository
    {
        private readonly TodoListContext _todoListContext;
          
        public TodoRepository(TodoListContext todoListContext) //конструктор нашего класса
        {
            _todoListContext = todoListContext;
        }
        public void Add(Todo todo)
        {
          _todoListContext.Add(todo);
          _todoListContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _todoListContext.Todoes
                 .Where(x => x.Id == id)
                 .ExecuteDelete();
        }

        public Todo? Get(int id)
        {
            return _todoListContext.Todoes
                 .AsNoTracking()
                 .Include(u => u.Category)
                 .FirstOrDefault(u => u.Id == id); //вернуть todo
             
                
        }

        public void Update(Todo todo)
        {
            _todoListContext.Todoes
             .Where(u => u.Id == todo.Id)
             .ExecuteUpdate(u => u
                 .SetProperty(x => x.Name, todo.Name) //устнаовить свойство
                 .SetProperty(x => x.IsEnd, todo.IsEnd)
                 .SetProperty(x => x.DateEnd, todo.DateEnd)
                 );
        }
    }
}
