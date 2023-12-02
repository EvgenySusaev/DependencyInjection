namespace DependencyInjection.WebApi.Dto;

public class GetLocationImageResponse
{
    public GetLocationImageResponse(string location)
    {
        Location = location;
    }

    public string Location { get; init; }
}