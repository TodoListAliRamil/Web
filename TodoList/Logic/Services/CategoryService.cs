using TodoList.Logic.Interfaces.Repositories;
using TodoList.Logic.Interfaces.Services;
using TodoList.Models.Entites;

namespace TodoList.Logic.Services;

public sealed class CategoryService : ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserService _userService;

    public CategoryService(ICategoryRepository categoryRepository, IUserService userService)
    {
        _categoryRepository = categoryRepository;
        _userService = userService;
    }

    public void Add(Category category)
    {
        var user = _userService.Get();
        category.UserId = user.Id;
        _categoryRepository.Add(category);
    }

    public void Delete(int id)
    {
        _categoryRepository.Delete(id);
    }

    public void Edit(Category category)
    {
        _categoryRepository.Update(category);
    }

    public Category Get(int id)
    {
        return _categoryRepository.Get(id) ?? throw new ArgumentException($"По данному ID = {id} категория не найдена");  
    }
} 
