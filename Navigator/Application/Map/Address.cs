namespace DependencyInjection.Navigator.Application.Map;

public class Address: ValueObject
{
    public string Street { get; init; }
    public string City { get; init; }
    public string Region { get; init; } 
    public string Country { get; init; }
    
    public Address(string street, string city, string region, string country)
    {
        Street = street;
        City = city;
        Region = region; 
        Country = country;
    }
    
    public override string ToString()
    {
        return $"{Country}, {Region}, {City}, {Street}"; 
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return Region; 
        yield return Country;
    }
}