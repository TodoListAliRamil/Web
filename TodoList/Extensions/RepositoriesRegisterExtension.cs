using Microsoft.EntityFrameworkCore;
using TodoList.Logic.Interfaces.Repositories;
using TodoList.Logic.Repositories;
using TodoList.Models.Context;

namespace TodoList.Extensions;

public static class RepositoriesRegisterExtension
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(TodoListContext));
        services.AddDbContext<TodoListContext>(x => x.UseNpgsql(connectionString), ServiceLifetime.Transient);
        return services;
    }


    //
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();
        return services;
    }
}
