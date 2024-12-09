using Microsoft.EntityFrameworkCore;
using TodoList.Logic.Interfaces.Repositories;
using TodoList.Models.Context;
using TodoList.Models.Entites;

namespace TodoList.Logic.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly TodoListContext _todoListContext; //поле нашего класса

    public UserRepository(TodoListContext todoListContext) //конструктор нашего класса
    {
        _todoListContext = todoListContext; //сохранение в памяти
    }

    public void Add(User user)
    {
        _todoListContext.Add(user);
        _todoListContext.SaveChanges();
    }


    public void Delete(int id)
    {
        _todoListContext.Users
            .Where(u => u.Id == id) //поиск пользователя по ID
            .ExecuteDelete(); //удалить пользовтеля 
    }


    public User? Get(string login)
    {
        return _todoListContext.Users
            .AsNoTracking()
            .Include(u => u.Categories) //inner join
            .FirstOrDefault(x => x.Login == login);
    }

    public void Update(User user)
    {
        _todoListContext.Users
            .Where(u => u.Id == user.Id)
            .ExecuteUpdate(u => u
                .SetProperty(x => x.Login, user.Login)
                .SetProperty(x => x.Password, user.Password)
            );
    }
}
