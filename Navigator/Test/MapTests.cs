using DependencyInjection.Navigator.Application.Map;
using NUnit.Framework;

namespace DependencyInjection.Navigator.Test;

[TestFixture]
public class MapTests
{
    private readonly IMap _map;

    public MapTests(IMap map)
    {
        _map = map;
    }
    
    [Test]
    public void StoringLocation_TwoLocations_Saved()
    {
        var barLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 1", "City", "State", "Country"),
            "bar image"
        );
        
        var homeLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 2", "City", "State", "Country"),
            "home image"
        );
        
        _map.StoreLocation(barLocation);
        _map.StoreLocation(homeLocation);
    }
    
    [Test]
    public void GettingLocationByAddress_Address_Got()
    {
        var barLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 1", "City", "State", "Country"),
            "bar image"
        );
        
        _map.StoreLocation(barLocation);

        var location = _map.FindLocationByAddress(
            new Address("Street name 1", "City", "State", "Country")
            );
    }
}