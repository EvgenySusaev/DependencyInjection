using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.Navigator.Application.Router;

public interface IMapRouter
{
    public Route BuildRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy);
}