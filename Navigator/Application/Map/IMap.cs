using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.Navigator.Application.Map;

public interface IMap
{
    public Location FindLocation(string locationName);
    public string GetLocationImage(Location location);
    public void StoreLocation(Location location);
}