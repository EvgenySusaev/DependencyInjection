namespace DependencyInjection.WebApi.Dto;

public class GetRouteResponse
{
    public GetRouteResponse(string route)
    {
        Route = route;
    }

    public string Route { get; init; }
}