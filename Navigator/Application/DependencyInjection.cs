using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Map.Map;
using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.Navigator.Application;

public static class DependencyInjection
{
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IMap, GoogleMap>();
        services.AddScoped<IMapRouter, GoogleMapRouter>();
        services.AddScoped<Navigator>();
    }
}