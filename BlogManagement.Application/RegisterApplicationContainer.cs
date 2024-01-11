using BlogManagement.Application.Profiles.ArticleCategories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogManagement.Application;

public static class RegisterApplicationContainer 
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
