using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.WebApi.Data.Map;
using IRouter = DependencyInjection.Navigator.Application.Router.IRouter;
using Router = DependencyInjection.WebApi.Data.Router.Router;

namespace DependencyInjection.WebApi;

public static class DependencyInjection
{
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IMap, Map>();
        services.AddScoped<IRouter, Router>();
        services.AddScoped<Navigator.Application.Navigator>();
    }
}