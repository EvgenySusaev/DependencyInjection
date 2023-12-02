using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.Navigator.Application.Map.Map;

public class YandexMap : IMap
{
    private readonly List<Location> _locations;

    public YandexMap()
    {
        _locations = new List<Location>
        {
            new Location(8, 9, "Coyote ugly"),
            new Location(8, 9, "Moscow city"),
        };
    }

    public Location FindLocation(string locationName)
    {
        Location location = _locations.Find(x => x.Names.Contains(locationName));
        
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