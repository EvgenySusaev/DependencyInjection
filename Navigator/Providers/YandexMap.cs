using DependencyInjection.Navigator.Interfaces;
using DependencyInjection.Navigator.Domain;

namespace DependencyInjection.Navigator.Providers;

public class YandexMap: IMapProvider
{
    public string GetLocation(Coordinate point)
    {
        return $"YandexMap: Land Image 400 x 400 of ({point.Latitude}\u00b0, {point.Longitude}\u00b0)";
    }

    public string GetRoute(Coordinate starPoint, Coordinate endPoint, RouteStrategy strategy)
    {
        return $"";
    }
}