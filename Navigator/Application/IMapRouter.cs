namespace DependencyInjection.Navigator.Application;

public interface IMapRouter
{
    public Route BuildRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy);
}