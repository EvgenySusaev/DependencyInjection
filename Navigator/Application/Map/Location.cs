namespace DependencyInjection.Navigator.Application.Map;

public class Location
{
    public Coordinates Coordinates { get; init; }
    public Address Address { get; init; }
    public string Image { get; set; }

    public Location(Coordinates coordinates, Address address, string image)
    {
        Coordinates = coordinates;
        Address = address;
        Image = image;
    }

    public override string ToString()
    {
        return $"({Address}: {Coordinates}";
    }
}