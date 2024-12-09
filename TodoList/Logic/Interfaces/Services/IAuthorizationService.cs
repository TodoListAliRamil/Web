using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Services;

public interface IAuthorizationService
{
    bool TryRegister(User user);//метод который проверяет можно ли регистрироваться или нет
    bool TryLogin(string login, string password);
    void Logout();
}
