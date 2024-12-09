using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Services;

public interface ICategoryServices
{
    void Add(Category category);
    void Delete(int id);
    void Edit(Category category);
    Category Get(int id);
}
