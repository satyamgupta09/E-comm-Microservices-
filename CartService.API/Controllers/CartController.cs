using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartService.API.Data;
using CartService.API.Model;
using System.Net.Http.Json;
using CartService.API.DTO;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly CartDbContext _context;
    private readonly HttpClient _httpClient;

    public CartController(CartDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cartItems = await _context.CartItems.ToListAsync();
        var result = new List<Object>();

        foreach(var item in cartItems)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductDto>(
    $"http://localhost:5001/api/products/{item.ProductId}");

            if (product != null)
            {
                result.Add(new
                 {
                    productId = product.Id,
                    name = product.Name,
                    qty = item.Quantity,
                    price = product.Price
                });
            }
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CartItem item)
    {
        var product = await _httpClient.GetFromJsonAsync<ProductDto>(
     $"http://localhost:5001/api/products/{item.ProductId}");

        if (product == null)
        {
            return BadRequest("Product not found");
        }

        _context.CartItems.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }
}