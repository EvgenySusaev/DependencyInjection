using DependencyInjection.Navigator.Application.Router;
using DependencyInjection.Navigator.Data.Map;

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