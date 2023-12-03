using DependencyInjection.Navigator.Application.Router;

namespace DependencyInjection.WebApi.Dto;

public class GetRouteByAddressesRequest
{
    public string OriginStreet { get; init; }
    public string OriginCity { get; init; }
    public string OriginState { get; init; }
    public string OriginCountry { get; init; }
    public string DestinationStreet { get; init; }
    public string DestinationCity { get; init; }
    public string DestinationState { get; init; }
    public string DestinationCountry { get; init; }
    
    public RouteStrategy RouteStrategy { get; init; }
}