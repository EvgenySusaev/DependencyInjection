using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.Navigator.Application.Router;

public interface IRouter
{
    public Route BuildRoute(
        Coordinates origin, 
        Coordinates destination,
        RouteStrategy strategy
        );
}