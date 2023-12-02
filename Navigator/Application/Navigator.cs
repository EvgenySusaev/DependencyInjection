using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.Navigator.Application;

public class Navigator
{
    private readonly IMap _map;
    private readonly IMapRouter _mapRouter;

    public Navigator(IMap map, IMapRouter mapRouter)
    {
        _map = map;
        _mapRouter = mapRouter;
    }

    public void ShowCurrentLocation()
    {
    }

    public void SaveLocation(Location location)
    {
        _map.StoreLocation(location);
    }
    
    public Location? GetLocationByAddress(Address address)
    {
        return _map.FindLocationBy(address);
    }
    
    public string GetImageByLocation(Location location)
    {
        return _map.GetLocationImage(location);
    }

    public Route GetRoute(Location sourcePoint, Location destinationPoint, RouteStrategy strategy)
    {
        return _mapRouter.BuildRoute(sourcePoint, destinationPoint, strategy);
    }
}