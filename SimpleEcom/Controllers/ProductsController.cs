namespace SimpleEcom.Controllers;
using Microsoft.AspNetCore.Mvc;
using Amazon.DynamoDBv2.DocumentModel;
using System.Threading.Tasks;
using SimpleEcom.Utilities;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly DynamoDBService _dynamoDbService;

    public ProductsController(DynamoDBService dynamoDbService)
    {
        _dynamoDbService = dynamoDbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await _dynamoDbService.GetItemAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product.ToJson());
    }

    [HttpPost]
    public async Task<IActionResult> PostItem([FromBody] dynamic data)
    {
        var document = Document.FromJson(data.ToString());
        await _dynamoDbService.PutItemAsync(document);
        return CreatedAtAction(nameof(GetProduct), new { id = document["Id"].AsString() }, document.ToJson());
    }

    // Add other endpoints (e.g., PUT, DELETE)
}