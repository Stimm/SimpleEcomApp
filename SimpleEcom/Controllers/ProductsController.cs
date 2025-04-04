namespace SimpleEcom.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using SimpleEcom.DataModels;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IDynamoDBContext _context;

    public ProductsController(IDynamoDBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await _context.LoadAsync<Product>(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.ScanAsync<Product>(default).GetRemainingAsync();
        return Ok(products);
    }

    // Add other endpoints (e.g., PUT, DELETE)
}