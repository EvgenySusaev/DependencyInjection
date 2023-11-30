namespace DependencyInjection.Navigator.Domain;

public class Route
{
    private const double EarthRadius = 6371;
    
    public Coordinate StartPoint { get; init; }
    public Coordinate EndPoint { get; init; }
    
    
    public Route(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
    {
        StartPoint = new Coordinate(startLatitude, startLongitude);
        EndPoint = new Coordinate(endLatitude, endLongitude);
    }
    
    public Route(Coordinate startPoint, Coordinate endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
    
    public double GetDistance()
    {
        double startLatitude = DegreesToRadians(StartPoint.Latitude);
        double startLongitude = DegreesToRadians(StartPoint.Longitude);
        double endLatitude = DegreesToRadians(EndPoint.Latitude);
        double endLongitude = DegreesToRadians(EndPoint.Longitude);
        
        double deltaLatitude = endLatitude - startLatitude;
        double deltaLongitude = endLongitude - startLongitude;
        
        double a = Math.Pow(Math.Sin(deltaLatitude / 2), 2) +
                   Math.Cos(startLatitude) * Math.Cos(endLatitude) *
                   Math.Pow(Math.Sin(deltaLongitude / 2), 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        
        double distance = EarthRadius * c;

        return distance;
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