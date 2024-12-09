using Microsoft.EntityFrameworkCore;
using TodoList.Logic.Interfaces.Repositories;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Logic.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly TodoListContext _todoListContext;

    public CategoryRepository(TodoListContext todoListContext) //конструктор нашего класса
    { 
        _todoListContext = todoListContext;
    }

    public void Add(Category category)
    {
        _todoListContext.Add(category);
        _todoListContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _todoListContext.Categories
            .Where(u => u.Id == id) //поиск пользователя по ID
            .ExecuteDelete(); //удалить пользовтеля 
    }
                                                                                                
    public Category? Get(int id)
    {
        return _todoListContext.Categories
            .AsNoTracking() //
            .Include(u => u.Todoes) //left join Include - чтобы устанавливать соединение
            .Include(u => u.User)
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Category category)
    {
        _todoListContext.Categories
             .Where(u => u.Id == category.Id)
             .ExecuteUpdate(u => u
                 .SetProperty(x => x.Name, category.Name)
             );
               
    }
}
