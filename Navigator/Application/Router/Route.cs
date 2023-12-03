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
    
    public Route(Coordinates startCoordinates, Coordinates endCoordinates)
    {
        StartCoordinates = startCoordinates;
        EndCoordinates = endCoordinates;
    }

    public Coordinates StartCoordinates { get; private set; }
    public Coordinates EndCoordinates { get; private set; }

    public double Distance
    {
        get
        {
            var sourceLatitude = DegreesToRadians(StartCoordinates.Latitude);
            var sourceLongitude = DegreesToRadians(StartCoordinates.Longitude);
            var destinationLatitude = DegreesToRadians(EndCoordinates.Latitude);
            var destinationLongitude = DegreesToRadians(EndCoordinates.Longitude);

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

    public double Direction
    {
        get{
            // Convert latitude and longitude from degrees to radians
            double phi1 = DegreesToRadians(StartCoordinates.Latitude);
            double lambda1 = DegreesToRadians(StartCoordinates.Longitude);
            double phi2 = DegreesToRadians(EndCoordinates.Latitude);
            double lambda2 = DegreesToRadians(EndCoordinates.Longitude);

            // Calculate the difference in longitudes
            double deltaLambda = lambda2 - lambda1;

            // Calculate the bearing using the atan2 function
            double y = Math.Sin(deltaLambda) * Math.Cos(phi2);
            double x = Math.Cos(phi1) * Math.Sin(phi2) - Math.Sin(phi1) * Math.Cos(phi2) * Math.Cos(deltaLambda);
            double bearing = Math.Atan2(y, x);

            // Convert the bearing from radians to degrees
            bearing = RadiansToDegrees(bearing);

            // Normalize the result to the range [0, 360)
            bearing = (bearing + 360) % 360;

            return bearing;
        }
    }
    
    public void UpdateDestination(Coordinates newDestination)
    {
        EndCoordinates = newDestination;
    }

    public override string ToString()
    {
        return $"start point: {StartCoordinates}, " +
               $"end point: {EndCoordinates}. " +
               $"Distance is {Distance}. " +
               $"Direction is {Direction}";
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