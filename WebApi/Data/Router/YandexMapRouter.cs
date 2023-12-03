using DependencyInjection.Navigator.Application;
using Route = DependencyInjection.Navigator.Application.Route;

namespace DependencyInjection.WebApi.Data.Router;

public class YandexMapRouter: IMapRouter
{
    public string GetRoute(Location starPoint, Location endPoint, RouteStrategy strategy)
    {
        return "";
    }

    public Route BuildRoute(Location startPoint, Location endPoint, RouteStrategy strategy)
    {
        throw new NotImplementedException();
    }
}