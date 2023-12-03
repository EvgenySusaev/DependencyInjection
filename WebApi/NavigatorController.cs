using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using RouteStrategy = DependencyInjection.Navigator.Application.Router.RouteStrategy;

namespace DependencyInjection.WebApi;

[ApiController]
[Route("[controller]/[action]")] 
public class NavigatorController: ControllerBase
{
    private readonly Navigator.Application.Navigator _navigator;
    
    public NavigatorController(Navigator.Application.Navigator navigator)
    {
        _navigator = navigator;
    }
    
    [HttpGet(Name="GetRouteByAddresses")]
    public GetRouteResponse GetRouteByAddresses([FromQuery]GetRouteByAddressesRequest request)
    {
        var origin = new Address(
            request.OriginStreet,
            request.OriginCity,
            request.OriginState,
            request.OriginCountry
            );
        
        var destination = new Address(
            request.DestinationStreet,
            request.DestinationCity,
            request.DestinationState,
            request.DestinationCountry
            );
        
        var routeDescription = _navigator.GetRoute(
            origin,
            destination,
            request.RouteStrategy
        );

        var response = new GetRouteResponse(routeDescription.ToString());
        return response;
    }
    
    [HttpGet(Name="GetRouteByCoordinates")]
    public GetRouteResponse GetRouteByCoordinates([FromQuery]GetRouteByCoordinatesRequest request)
    {
        var origin = new Coordinates(request.OriginLatitude, request.OriginLongitude);
        var destination = new Coordinates(request.DestinationLatitude, request.DestinationLongitude);

        var route = _navigator.GetRoute(
            origin,
            destination,
            request.RouteStrategy
        );

        var response = new GetRouteResponse(route.ToString());
        return response;
    }
    
    [HttpGet(Name="GetLocationByAddress")]
    public GetLocationResponse GetLocationByAddress([FromQuery]GetLocationRequest request)
    {
        var address = new Address(
            request.Street,
            request.City,
            request.State,
            request.Country
        );
        
        var location = _navigator.GetLocationBy(address);
        var name = location?.ToString() ?? "";
        
        var response = new GetLocationResponse(name);
        return response;
    }
}