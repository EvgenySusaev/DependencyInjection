using DependencyInjection.Navigator.Domain;

namespace DependencyInjection.Navigator.Interfaces;

public interface IMapProvider
{
    public string GetLocation(Coordinate point);
    public string GetRoute(Coordinate startPoint, Coordinate endPoint, RouteStrategy strategy);
}