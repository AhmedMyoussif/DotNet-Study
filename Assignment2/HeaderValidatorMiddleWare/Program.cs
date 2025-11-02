/*
Check if the context contains a custom security header
(e.g., X-Auth-Token). Verify:
1. The header exists.
2. The header’s value matches a predefined token
(you can hard-code the token for this assignment).
 If either condition fails, return a 400 Bad Request with a
message like: "Invalid or missing authentication token."
 If the token matches, allow the request to proceed.
*/

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.Use(async (context, next) =>
{
    const string custom_security_header = "X-Auth-Token";
    const string predefinedToken = "12345";

    if (!context.Request.Headers.ContainsKey(custom_security_header))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid or missing authentication token.");

        return;
    }

    var tokenValue = context.Request.Headers[custom_security_header].ToString();

    if (tokenValue != predefinedToken)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid or missing authentication token.");
        return;
    }
    
     await next();
       
});


app.MapGet("/", () => "Authenticated!");

app.Run();
