using DependencyInjection.Navigator.Application;
using DependencyInjection.Navigator.Application.GeoLocation;
using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using DependencyInjection.WebApi.Data.Map;
using DependencyInjection.WebApi.Data.Router;

namespace DependencyInjection.WebApi;

public static class DependencyInjection
{
    public static void Load(IServiceCollection services)
    {
        services.AddScoped<IMap, GoogleMap>();
        services.AddScoped<IMapRouter, GoogleMapRouter>();
        services.AddScoped<Navigator.Application.Navigator>();
    }
}