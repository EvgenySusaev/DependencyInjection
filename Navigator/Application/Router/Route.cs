using DependencyInjection.Navigator.Application.Map;

namespace DependencyInjection.Navigator.Application.Router;

public enum RouteStrategy
{
    ByFoot,
    Public,
    Car
}

public class Route
{
    private const double EarthRadius = 6371;
    
    public Route(Location startLocation, Location endLocation)
    {
        StartLocation = startLocation;
        EndLocation = endLocation;
        Directions = new List<string>();
    }

    public Location StartLocation { get; private set; }
    public Location EndLocation { get; private set; }
    public List<string> Directions { get; private set; }

    public double Distance
    {
        get
        {
            var sourceLatitude = DegreesToRadians(StartLocation.Coordinates.Latitude);
            var sourceLongitude = DegreesToRadians(StartLocation.Coordinates.Longitude);
            var destinationLatitude = DegreesToRadians(EndLocation.Coordinates.Latitude);
            var destinationLongitude = DegreesToRadians(EndLocation.Coordinates.Longitude);

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
    
    public void CalculateRoute()
    {

    }
    
    public void UpdateDestination(Location newDestination)
    {
        EndLocation = newDestination;
    }

    public override string ToString()
    {
        return $"start point: {StartLocation}" +
               $", end point: {EndLocation}. " +
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