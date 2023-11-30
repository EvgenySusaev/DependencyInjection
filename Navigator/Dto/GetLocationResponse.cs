namespace DependencyInjection.Navigator.Dto;

public class GetLocationResponse
{
    public GetLocationResponse(string location)
    {
        Location = location;
    }

    public string Location { get; init; }
}