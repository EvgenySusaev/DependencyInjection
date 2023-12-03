namespace DependencyInjection.Navigator.Application.Map;

public class Location
{
    public Coordinates Coordinates { get; init; }
    public Address Address { get; init; }

    public Location(Coordinates coordinates, Address address)
    {
        Coordinates = coordinates;
        Address = address;
    }

    public override string ToString()
    {
        return $"({Address}: ({Coordinates.Latitude}\u00b0, {Coordinates.Longitude}\u00b0)";
    }
}