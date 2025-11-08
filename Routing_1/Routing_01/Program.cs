
using System.Net;
using Microsoft.AspNetCore.Routing;

/// What is Routing => Routing is the process of Mapping incoming Requests 
/// to corresponding handler functions, based on the request URL and Http method. 
/// Request 1 => Routing => endpoint 1
/// Request 2 => Routing => endpoint 2
/// How To enable Routing ??  :  app.UseRouting();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.MapGet("/products", () =>
{
    return Results.Ok(new[]{
          "Product #1" ,
          "Product #2"
    });
});

app.MapGet("/route-table", (IServiceProvider sp) =>
{
    var endpoints = sp.GetRequiredService<EndpointDataSource>()
    .Endpoints.Select(ep => ep.DisplayName);
      return Results.Ok(endpoints);
});


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("mapget1", async context => // localhost:5000/mapget1 , GET
    {
        await context.Response.WriteAsync("map get 1");
    });
    endpoints.MapGet("mapget2", async context => // localhost:5000/mapget1 , GET
    {
        await context.Response.WriteAsync("map get 2");
    });

    endpoints.MapGet("mapget3", async context => // localhost:5000/mapget1 , GET
    {
        await context.Response.WriteAsync("map get 3");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("default route");
});
app.Run();
