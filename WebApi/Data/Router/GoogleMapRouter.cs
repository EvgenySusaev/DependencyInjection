using DependencyInjection.Navigator.Application;
using Route = DependencyInjection.Navigator.Application.Route;

namespace DependencyInjection.WebApi.Data.Router;

public class GoogleMapRouter: IMapRouter
{
    public Route BuildRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy)
    {
        return new Route(sourcePoint, destinationPoint);
    }
}