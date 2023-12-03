namespace DependencyInjection.WebApi.Dto;

public class GetLocationRequest
{
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
}