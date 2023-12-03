using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using IRouter = DependencyInjection.Navigator.Application.Router.IRouter;
using Route = DependencyInjection.Navigator.Application.Router.Route;

namespace DependencyInjection.Navigator.Application;

public class Navigator
{
    private readonly IMap _map;
    private readonly IRouter _router;

    public Navigator(IMap map, IRouter router)
    {
        _map = map;
        _router = router;
    }

    public void SaveLocation(Location location)
    {
        _map.StoreLocation(location);
    }
    
    public Location? GetLocationBy(Address address)
    {
        return _map.FindLocationByAddress(address);
    }
    
    public Route GetRoute(Address origin, Address destination, RouteStrategy strategy)
    {
        Location? startLocation = _map.FindLocationByAddress(origin);
        Location? endLocation = _map.FindLocationByAddress(destination);

        if (startLocation is null || endLocation is null)
        {
            throw new Exception();
        }
        
        return _router.BuildRoute(
            startLocation.Coordinates,
            endLocation.Coordinates,
            strategy);
    }

    public Route GetRoute(
        string originStreet, string originCity, string originState, string originCountry,
        string destinationStreet, string destinationCity, string destinationState, string destinationCountry,
        RouteStrategy strategy
        )
    {
        Address originAddress = new Address(
            originStreet,
            originCity,
            originState,
            originCountry
            );
        Address destinationAddress = new Address(
            destinationStreet,
            destinationCity,
            destinationState,
            destinationCountry
            );
        
        return GetRoute(originAddress, destinationAddress, strategy);
    }
    
    public Route GetRoute(Coordinates origin, Coordinates destination, RouteStrategy strategy)
    {
        return _router.BuildRoute(
            origin,
            destination,
            strategy);
    }
}