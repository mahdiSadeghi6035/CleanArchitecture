using BlogManagement.Application.Profiles.ArticleCategories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogManagement.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
