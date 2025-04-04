using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using SimpleEcom.DataModels;

namespace SimpleEcom.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IDynamoDBContext _context;

    public ItemsController(IDynamoDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _context.ScanAsync<Item>(default).GetRemainingAsync();

        return Ok(items);
    }

}
