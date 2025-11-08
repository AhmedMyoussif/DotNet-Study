using Microsoft.AspNetCore.Mvc;
namespace Routing_01.Controllers;
// Products 
[ApiController]
[Route("[controller]")]

public class ProductsController : ControllerBase
{
    // products/all
    [HttpGet("all")]
    public IActionResult GetProducts()
    {
        return Ok(new[]{
          "Product #1" ,
          "Product #2"
        });
    }

}

