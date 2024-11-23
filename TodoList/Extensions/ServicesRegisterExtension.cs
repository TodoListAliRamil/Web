using TodoList.Logic.Interfaces.Services;
using TodoList.Logic.Services;

namespace TodoList.Extensions;

public static  class ServicesRegisterExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICryptoService, CryptoService>();
        return services;
    }
}
