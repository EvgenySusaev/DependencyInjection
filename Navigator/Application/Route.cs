using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.Navigator.Application;

public enum RouteStrategy
{
    ByFoot,
    Public,
    Car
}

public class Route
{
    private const double EarthRadius = 6371;

    public Route(double sourceLatitude, double sourceLongitude, double destinationLatitude, double destinationLongitude)
    {
        SourcePoint = new Location(sourceLatitude, sourceLongitude);
        DestinationPoint = new Location(destinationLatitude, destinationLongitude);
    }

    public Route(Location sourcePoint, Location destinationPoint)
    {
        SourcePoint = sourcePoint;
        DestinationPoint = destinationPoint;
    }

    public Location SourcePoint { get; init; }
    public Location DestinationPoint { get; init; }

    public double Distance
    {
        get
        {
            var sourceLatitude = DegreesToRadians(SourcePoint.Latitude);
            var sourceLongitude = DegreesToRadians(SourcePoint.Longitude);
            var destinationLatitude = DegreesToRadians(DestinationPoint.Latitude);
            var destinationLongitude = DegreesToRadians(DestinationPoint.Longitude);

            var deltaLatitude = destinationLatitude - sourceLatitude;
            var deltaLongitude = destinationLongitude - sourceLongitude;

            var a = Math.Pow(Math.Sin(deltaLatitude / 2), 2) +
                    Math.Cos(sourceLatitude) * Math.Cos(destinationLatitude) *
                    Math.Pow(Math.Sin(deltaLongitude / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = EarthRadius * c;

            return distance;
        }
    }

    public override string ToString()
    {
        return $"Land Image 400 x 400 for " +
               $"start point: {SourcePoint}" +
               $", end point: {DestinationPoint}. " +
               $"Distance is {Distance}.";
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }

    private static double RadiansToDegrees(double radians)
    {
        return radians * 180 / Math.PI;
    }
}