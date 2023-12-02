using DependencyInjection.Navigator.Application;

namespace DependencyInjection.Navigator.Data.Map;

public class YandexMap : IMap
{
    private readonly List<Location> _locations = new List<Location>();

    public YandexMap()
    {
    }

    public Coordinates? FindGeolocationBy(Address address)
    {
        Location location = _locations.FirstOrDefault(l => l.Address == address
        );
        return location?.Coordinates;
    }
    
    public Location? FindLocationBy(Address address)
    {
        Location location = _locations.FirstOrDefault(l => l.Address.Equals(address));
        return location;
    }
    
    public string GetLocationImage(Location location)
    {
        return $"Image of {location} from YandexMap";
    }

    public void StoreLocation(Location location)
    {
        _locations.Add(location);
    }
}