using TodoList.Models.Entites;

namespace TodoList.Logic.Interfaces.Repositories;

public interface ICategoryRepository
{
    void Add(Category category);
    void Delete(int id);
    void Update(Category category);
    Category? Get(int id);
}
