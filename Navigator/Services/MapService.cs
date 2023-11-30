using DependencyInjection.Navigator.Interfaces;
using DependencyInjection.Navigator.Domain;

namespace DependencyInjection.Navigator.Services;

public class MapService
{
    private readonly IMapProvider _mapProvider;

    public MapService(IMapProvider mapProvider)
    {
        _mapProvider = mapProvider;
    }

    public string GetLocation(Coordinate point)
    {
        return _mapProvider.GetLocation(point);
    }

    public string GetRoute(Coordinate startPoint, Coordinate endPoint, RouteStrategy strategy)
    {
        return _mapProvider.GetRoute(startPoint, endPoint, strategy);
    }
}