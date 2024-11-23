using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Repositories;

public interface IUserRepository
{
    void Update(User user);
    void Delete(int id);
    void Add(User user);
}



