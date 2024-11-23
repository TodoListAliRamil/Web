using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Repositories;

public interface IUserRepository
{
    User? Get(string login);
    void Update(User user);
    void Delete(int id);
    void Add(User user);
}



