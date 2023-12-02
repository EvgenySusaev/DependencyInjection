namespace DependencyInjection.Navigator.Application.Map;

public class Location
{
    public Location(double latitude, double longitude, params string[] names)
    {
        Names = new List<string>();
        Latitude = latitude;
        Longitude = longitude;
        
        if (names.Any())
        {
            Names.AddRange(names);
        }
    }
    
    public List<string> Names { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public void AddName(string name)
    {
        Names.Add(name);
    }
    
    public void RemoveName(string name)
    {
        Names.Remove(name);
    }

    public override string ToString()
    {
        var locationNames = Names.Any() 
            ? $"{string.Join(", ", Names)}: " 
            : string.Empty;
        
        return $"({locationNames}({Latitude}\u00b0, {Longitude}\u00b0)";
    }
}