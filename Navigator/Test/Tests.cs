using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using NUnit.Framework;

namespace DependencyInjection.Navigator.Test;

[TestFixture]
public class Tests
{
    private readonly Application.Navigator _navigator;

    public Tests(Application.Navigator navigator)
    {
        _navigator = navigator;
        
        // Fill map with data
        
        var startLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 1", "City", "State", "Country")
        );
        
        var endLocation = new Location(
            new Coordinates(7, 9),
            new Address("Street name 2", "City", "State", "Country")
        );
        
        _navigator.SaveLocation(startLocation);
        _navigator.SaveLocation(endLocation);
    }
    [Test]
    public void GetRoute()
    {
        // e.g. from web request
        var startAddress = new Address("Street name 1", "City", "State", "Country");
        var endAddress = new Address("Street name 2", "City", "State", "Country");

        // data request
        var startLocation = _navigator.GetLocationByAddress(startAddress);
        var endLocation = _navigator.GetLocationByAddress(endAddress);
        
        // work with requested data
        var bar = _navigator.GetLocationByAddress(startLocation.Address);
        var home = _navigator.GetLocationByAddress(endLocation.Address);
        
        var route = _navigator.GetRoute(bar, home, RouteStrategy.Car);
        
    } 
}
