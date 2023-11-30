namespace DependencyInjection.Navigator.Dto;

public class GetRouteRequest
{
    public double StartLatitude { get; private set; }
    public double StartLongitude { get; private set; }
    public double EndLatitude { get; private set; }
    public double EndLongitude { get; private set; }
    public RouteStrategy RouteStrategy { get; private set; }
}

public enum RouteStrategy
{
    ByFoot,
    Public,
    Car
}