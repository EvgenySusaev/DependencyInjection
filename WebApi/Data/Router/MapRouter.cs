using DependencyInjection.Navigator.Application;
using Route = DependencyInjection.Navigator.Application.Route;

namespace DependencyInjection.WebApi.Data.Router;

public class MapRouter: IMapRouter
{
    public Route BuildRoute(Location startPoint, Location endPoint, RouteStrategy strategy)
    {
        Route route = strategy switch
        {
            RouteStrategy.Car => new Route(startPoint, endPoint),
            RouteStrategy.ByFoot => new Route(startPoint, endPoint),
            RouteStrategy.Public => new Route(startPoint, endPoint),
            _ => throw new NotImplementedException()
        };
        return route;
    }
}