using DependencyInjection.Navigator.Interfaces;
using DependencyInjection.Navigator.Providers;
using DependencyInjection.Navigator.Services;

namespace DependencyInjection.Navigator;

public class DependencyInjection 
{
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IMapProvider, GoogleMap>();
        services.AddScoped<MapService>();
    }
}