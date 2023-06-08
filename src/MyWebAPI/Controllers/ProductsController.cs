using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Services.Storage;

namespace MyWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IStorageService _storageService;

    public ProductsController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _storageService.GetAllData();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _storageService.GetDataById(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}

