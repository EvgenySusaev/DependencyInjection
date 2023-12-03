namespace DependencyInjection.Navigator.Application.Map;

public class Coordinates: ValueObject
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public Coordinates(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
    }

    public override string ToString()
    {
        return $"({Latitude}\u00b0, {Longitude}\u00b0)";
    }
}