namespace DependencyInjection.Navigator.Application.Map;

public interface IMap
{
    public Location? FindLocationByAddress(Address address);
    public void StoreLocation(Location location);
}