namespace DependencyInjection.Navigator.Application.Router;

public class GoogleMapRouter: IMapRouter
{
    public Route BuildRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy)
    {
        return new Route(sourcePoint, destinationPoint);
    }
}