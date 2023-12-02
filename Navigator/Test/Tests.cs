using DependencyInjection.Navigator.Application;
using DependencyInjection.Navigator.Application.Map;
using NUnit.Framework;

namespace DependencyInjection.Navigator.Test;

[TestFixture]
public class Tests
{
    private readonly Application.Navigator _navigator;

    public Tests(Application.Navigator navigator)
    {
        _navigator = navigator;
    }
    [Test]
    public void GetRoute()
    {
        _navigator.SaveLocation(new Location(8, 9, "Coyote ugly"));
        _navigator.SaveLocation(new Location(18, 19, "Moscow City"));
        
        var bar = _navigator.GetLocationByName("Coyote ugly");
        var home = _navigator.GetLocationByName("Moscow City");
        
        var route = _navigator.GetRoute(bar, home, RouteStrategy.Car);
        
    } 
}
