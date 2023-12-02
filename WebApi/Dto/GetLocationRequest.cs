namespace DependencyInjection.WebApi.Dto;

public class GetLocationRequest
{
    public GetLocationRequest(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}