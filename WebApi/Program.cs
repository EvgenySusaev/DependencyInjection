using Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Autofac
// builder.Host.UseServiceProviderFactory(
//     new AutofacServiceProviderFactory(
//         x => x.RegisterType<StringBuilder>().AsSelf()
//     )
// );

DependencyInjection.WebApi.DependencyInjection.Load(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();