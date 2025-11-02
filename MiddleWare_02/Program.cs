var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// To See how components are Executed One After Another Use app.Use() Instead of app.Run() 
// It Take request delegate and refers to the next see... 



app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Before1\n");
    await next(httpContext);
     await httpContext.Response.WriteAsync("After1\n");
});

app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Before2\n");
    await next(httpContext);
     await httpContext.Response.WriteAsync("After2\n");
});


app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Before3\n");
    await next();
    await httpContext.Response.WriteAsync("After3\n");
});


app.Run(async httpContext =>
{
    await httpContext.Response.WriteAsync("Final Component\n");
});





// If We Want To Use App.Use And Not Want To Execute The Next ! , 
// Here We Must Dedicate The Types , See 


/*app.Use(async (HttpContext httpContext, RequestDelegate next) =>
{
    await httpContext.Response.WriteAsync("Hello\n");
});

app.Run(async httpContext =>
{
    await httpContext.Response.WriteAsync("Final Component\n");
});*/


app.Run();
