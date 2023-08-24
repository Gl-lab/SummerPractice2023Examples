using ConsoleApp1;
using Domain;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture;
public static  class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>( sp => sp.GetService<ApplicationContext>() );
      
    }
}
