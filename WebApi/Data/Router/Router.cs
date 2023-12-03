using DependencyInjection.Navigator.Application.Map;
using DependencyInjection.Navigator.Application.Router;
using IRouter = DependencyInjection.Navigator.Application.Router.IRouter;
using Route = DependencyInjection.Navigator.Application.Router.Route;

namespace DependencyInjection.WebApi.Data.Router;

public class Router: IRouter
{
    public Router()
    {
    }

    public Route BuildRoute(Coordinates start, Coordinates end, RouteStrategy strategy)
    {
        Route route = strategy switch
        {
            RouteStrategy.Car => new Route(start, end),
            RouteStrategy.ByFoot => new Route(start, end),
            RouteStrategy.Public => new Route(start, end),
            _ => throw new NotImplementedException()
        };
        return route;
    }
}