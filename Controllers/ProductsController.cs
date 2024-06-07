using YourNamespace.Data;
using YourNamespace.Models;
using Microsoft.AspNetCore.Mvc;

[Route("products")]
public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts(string search)
    {
        try
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search));
            }

            var products = query.ToList();

            return Json(products);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}