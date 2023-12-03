namespace DependencyInjection.Navigator.Application.Map;

public interface IMap
{
    public Coordinates? FindGeolocationBy(Address address);
    public Location? FindLocationBy(Address address);
    public string GetLocationImage(Location location);
    public void StoreLocation(Location location);
}