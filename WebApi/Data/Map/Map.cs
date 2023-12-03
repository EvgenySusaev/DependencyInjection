using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.WebApi.Data.Map;

public class Map : IMap
{
    private readonly List<Location> _locations = new List<Location>();

    public Map()
    {
        var barLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 1", "City", "State", "Country"),
            "bar image"
        );
        
        var homeLocation = new Location(
            new Coordinates(17, 19),
            new Address("Street name 2", "City", "State", "Country"),
            "home image"
        );
        
        
        _locations.Add(barLocation);
        _locations.Add(homeLocation);
    }

    public Location? FindLocationByAddress(Address address)
    {
        Location location = _locations.FirstOrDefault(l => l.Address.Equals(address));
        return location;
    }

    public void StoreLocation(Location location)
    {
        _locations.Add(location);
    }
}