﻿using Microsoft.EntityFrameworkCore;
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

}