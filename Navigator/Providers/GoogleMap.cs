using DependencyInjection.Navigator.Interfaces;
using DependencyInjection.Navigator.Domain;

namespace DependencyInjection.Navigator.Providers;

public class GoogleMap: IMapProvider
{
    public string GetLocation(Coordinate point)
    {
        return $"GoogleMap: Land Image 400 x 400 of ({point.Latitude}\u00b0, {point.Longitude}\u00b0)";
    }

    public string GetRoute(Coordinate startPoint, Coordinate endPoint, RouteStrategy strategy)
    {
        return $"GoogleMap: Land Image 400 x 400 for " +
               $"start point: ({startPoint.Latitude}\u00b0, {startPoint.Longitude}\u00b0)" +
               $", end point: ({endPoint.Latitude}\u00b0, {endPoint.Longitude}\u00b0).";
    }
}