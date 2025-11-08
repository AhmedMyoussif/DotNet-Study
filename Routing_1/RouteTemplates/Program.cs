using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

/// Tokens Within {..} in the route segment define route parameters 
/// that are bound if the route is matched .More than one Route 
/// parameters can be defined in a route segment , but route 
/// parameters must be separated by a literal value.

var app = builder.Build();

app.MapGet("/product/{id}", (int id) => $"product {id}");

/// Now I Want to send More than one Route Parameter
app.MapGet("/date/{year}-{month}-{day}", (int year, int month, int day)
=> $"Date is {new DateOnly(year , month , day)}");


// default value
app.MapGet("/{controller=Home}", (string? controller) => controller);

// Optional 
app.MapGet("/users/{id?}", (int? id) => id is null ? "All Users" : $"User{id}");
app.Run();
