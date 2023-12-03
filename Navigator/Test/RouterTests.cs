using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using IRouter = DependencyInjection.Navigator.Application.Router.IRouter;
using NUnit.Framework;

namespace DependencyInjection.Navigator.Test;

[TestFixture]
public class RouterTests
{
    private readonly IRouter _router;

    public RouterTests(IRouter router)
    {
        _router = router;
    }
    
    [Test]
    public void BuildingRoute_TwoAddress_ValidRoute()
    {
        var barCoordinates = new Coordinates(7, 9);
        var homeCoordinates = new Coordinates(17, 19);
        
        var route = _router.BuildRoute(
            barCoordinates,
            homeCoordinates,
            RouteStrategy.Car
            );
    } 
}