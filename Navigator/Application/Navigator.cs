using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using IRouter = DependencyInjection.Navigator.Application.Router.IRouter;
using Route = DependencyInjection.Navigator.Application.Router.Route;

namespace DependencyInjection.Navigator.Application;

public record Navigator
{
    private readonly IMap _map;
    private readonly IRouter _router;
    
    public Navigator(IMap map, IRouter router)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map));
        _router = router ?? throw new ArgumentNullException(nameof(router));
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
        Location? startLocation = GetVerifiedLocationByAddress(origin);
        Location? endLocation = GetVerifiedLocationByAddress(destination);
        
        return _router.BuildRoute(
            startLocation.Coordinates,
            endLocation.Coordinates,
            strategy);
    }
    
    public Route GetRoute(
        string originStreet, string originCity, string originRegion, string originCountry,
        string destinationStreet, string destinationCity, string destinationRegion, string destinationCountry,
        RouteStrategy strategy
    )
    {
        Address originAddress = new Address(
            originStreet,
            originCity,
            originRegion,
            originCountry
        );
        Address destinationAddress = new Address(
            destinationStreet,
            destinationCity,
            destinationRegion,
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

    private Location GetVerifiedLocationByAddress(Address address)
    {
        Location? location = _map.FindLocationByAddress(address);
        if (location is null)
        {
            throw new Exception($"Could not find a location with the address: {address}");
        }
        
        return location;
    }
}