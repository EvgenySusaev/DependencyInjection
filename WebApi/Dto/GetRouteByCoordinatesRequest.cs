using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.WebApi.Dto;

public class GetRouteByCoordinatesRequest
{
    public double OriginLatitude { get; init; }
    public double OriginLongitude { get; init; }
    public double DestinationLatitude { get; init; }
    public double DestinationLongitude { get; init; }
    public RouteStrategy RouteStrategy { get; init; }
}