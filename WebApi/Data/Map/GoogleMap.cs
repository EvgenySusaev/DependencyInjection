using DependencyInjection.Navigator.Application;
using DependencyInjection.Navigator.Application.GeoLocation;
using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.WebApi.Data.Map;

public class GoogleMap : IMap
{
    private readonly List<Location> _locations = new List<Location>();

    public GoogleMap()
    {
    }

    public Coordinates? FindGeolocationBy(Address address)
    {
        Location location = _locations.FirstOrDefault(l => l.Address == address);
        return location?.Coordinates;
    }
    
    public Location? FindLocationBy(Address address)
    {
        Location location = _locations.FirstOrDefault(l => l.Address.Equals(address));
        return location;
    }
    
    public string GetLocationImage(Location location)
    {
        return $"Image of {location} from GoogleMap";
    }

    public void StoreLocation(Location location)
    {
        _locations.Add(location);
    }
}