namespace DependencyInjection.Navigator.Application.Router;

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