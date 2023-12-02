using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.Navigator.Application.Map.Map;

public class GoogleMap : IMap
{
    private readonly List<Location> _locations = new()
    {
        new Location(8, 9, "Coyote ugly"),
        new Location(18, 19, "Moscow city"),
    };

    public Location FindLocation(string locationName)
    {
        Location location = _locations.Find(x => x.Names.Contains(locationName));
        
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