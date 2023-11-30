using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Navigator.Services;
using DependencyInjection.Navigator.Domain;
using DependencyInjection.Navigator.Dto;
using RouteStrategy = DependencyInjection.Navigator.Domain.RouteStrategy;

namespace DependencyInjection.Navigator.Controllers;

[ApiController]
[Route("[controller]/[action]")] 
public class NavigatorController: ControllerBase
{
    private readonly MapService _mapService;
    
    public NavigatorController(MapService mapService)
    {
        _mapService = mapService;
    }
    
    [HttpGet(Name="GetRoute")]
    public GetRouteResponse GetRoute([FromQuery]GetRouteRequest request)
    {
        var startPoint = new Coordinate(
            request.StartLatitude,
            request.StartLongitude
            );
        
        var endPoint = new Coordinate(
            request.EndLatitude,
            request.EndLongitude
        );

        var strategy = request.RouteStrategy;
        
        var routeDescription = _mapService.GetRoute(
            startPoint,
            endPoint,
            (RouteStrategy)strategy
            );

        var response = new GetRouteResponse(routeDescription);

        return response;
    }
    
    [HttpGet(Name="GetLocation")]
    public GetLocationResponse GetLocation([FromQuery]GetLocationRequest request)
    {
        var point = new Coordinate(
            request.Latitude,
            request.Longitude
        );
        
        var locationDescription = _mapService.GetLocation(
            point
        );

        var response = new GetLocationResponse(locationDescription);

        return response;
    }
}