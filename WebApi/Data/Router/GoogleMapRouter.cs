using DependencyInjection.Navigator.Application;
using DependencyInjection.Navigator.Application.GeoLocation;
using DependencyInjection.Navigator.Application.Router;
using Route = DependencyInjection.Navigator.Application.Router.Route;

namespace DependencyInjection.WebApi.Data.Router;

public class GoogleMapRouter: IMapRouter
{
    public Route BuildRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy)
    {
        return new Route(sourcePoint, destinationPoint);
    }
}