using DependencyInjection.Navigator.Application;
using DependencyInjection.Navigator.Application.Map;
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
            request.StartLatitude,
            request.StartLongitude
            );
        
        var endPoint = new Location(
            request.EndLatitude,
            request.EndLongitude
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
        var location = _navigator.GetLocationByName(
            request.Name
        );
        var name = location?.ToString() ?? "";
        var response = new GetLocationResponse(name);

        return response;
    }
    
    [HttpGet(Name="GetLocationImage")]
    public GetLocationImageResponse GetLocationImage([FromQuery]GetLocationImageRequest request)
    {
        var point = new Location(
            request.Latitude,
            request.Longitude
        );
        
        var locationDescription = _navigator.GetImageByLocation(
            point
        );

        var response = new GetLocationImageResponse(locationDescription);

        return response;
    }
}