using DependencyInjection.Navigator.Application;
using DependencyInjection.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using RouteStrategy = DependencyInjection.Navigator.Application.RouteStrategy;

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
    
    [HttpGet(Name="GetRoute")]
    public GetRouteResponse GetRoute([FromQuery]GetRouteRequest request)
    {
        var startPoint = new Location( 
            new Coordinates(request.StartLatitude, request.StartLongitude)
            , new Address("","","","")
        );
        
        var endPoint = new Location( 
            new Coordinates(request.EndLatitude, request.EndLongitude)
            , new Address("","","","")
        );

        var strategy = request.RouteStrategy;
        
        var routeDescription = _navigator.GetRoute(
            startPoint,
            endPoint,
            (RouteStrategy)strategy
            );

        var response = new GetRouteResponse(routeDescription.ToString());

        return response;
    }
    
    [HttpGet(Name="GetLocation")]
    public GetLocationResponse GetLocation([FromQuery]GetLocationRequest request)
    {
        var location = _navigator.GetLocationByAddress(
            new Address("street", "city", "state", "country")
        );
        var name = location?.ToString() ?? "";
        var response = new GetLocationResponse(name);

        return response;
    }
    
    [HttpGet(Name="GetLocationImage")]
    public GetLocationImageResponse GetLocationImage([FromQuery]GetLocationImageRequest request)
    {
        var point = new Location( 
            new Coordinates(request.Latitude, request.Longitude)
            , new Address("","","","")
        );
        
        var locationDescription = _navigator.GetImageByLocation(
            point
        );

        var response = new GetLocationImageResponse(locationDescription);

        return response;
    }
}