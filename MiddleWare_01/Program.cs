var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// MiddleWares Is A Set Of Components (Method , Class) That run one after another when request comes in . 

/*app.Run(async httpContext =>        /// app.run it is a short circuit that doesn't Pass  the Request to the next Component . 
{
    await httpContext.Response.WriteAsync("hello");
});*/

/*app.Run(async httpContext =>        /// Not Executed Cause af the first component is app.Run . 
{
    await httpContext.Response.WriteAsync("hello2");  
});*/


app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Hello1\n");
    await next();
});

app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Hello2\n");
    await next();
});


app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Hello3\n");
    await next();
});


app.Run(async httpContext =>
{
    await httpContext.Response.WriteAsync("Final Component\n");
});


app.Run();
