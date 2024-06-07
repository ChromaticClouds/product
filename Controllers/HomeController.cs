using YourNamespace.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace YourNamespace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            var register = await _context.Register.ToListAsync();

            return View(register);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var products = await _context.Products.ToListAsync();
            var allPrice = await _context.Products.SumAsync(p => p.Price * p.Count);
            var allCount = await _context.Products.SumAsync(p => p.Count);

            ViewBag.AllPrice = allPrice;
            ViewBag.AllCount = allCount;
            return View(products);
        }

        public IActionResult IOBinfo()
        {
            var products = _context.Products.ToList();
            var inventories = _context.Inventory.ToList();
            var register = _context.Register.ToList();
            
            var viewModel = new MultiView
            {
                Products = products,
                Inventory = inventories,
                Register = register
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult RegisterOutbound([FromBody] List<Inventory> orders)
        {
            foreach (var order in orders)
            {
                var product = _context.Products.FirstOrDefault(p => p.RegisterID == order.RegisterID);

                if (product == null)
                {
                    return NotFound(new { success = false, message = "상품을 찾을 수 없습니다." });
                }

                // 현재 재고 계산
                var totalQuantity = _context.Inventory
                    .Where(i => i.RegisterID == order.RegisterID)
                    .Sum(i => i.TotalQuantity);

                // 입고일이 현재 날짜 이후인 경우를 제외한 수량 계산
                var inBoundCount = _context.Products
                    .Where(p => p.RegisterID == order.RegisterID && p.InBound.Ticks <= DateTime.Today.Ticks)
                    .Sum(p => p.Count);

                var availableQuantity = totalQuantity - inBoundCount;

                if (order.TotalQuantity > availableQuantity)
                {
                    return BadRequest(new { success = false, message = "재고가 부족합니다." });
                }

                var newProduct = new Product
                {
                    RegisterID = order.RegisterID,
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    Price = product.Price,
                    Status = "출고",
                    Count = order.TotalQuantity,
                    InBound = DateTime.Today
                };
                _context.Products.Add(newProduct);

                _context.SaveChanges();
            }

            return Ok(new { success = true });
        }

        public IActionResult Order()
        {
            var order = _context.Register;
            return View(order);
        }


        [HttpPost]
        public IActionResult RegisterProduct([FromBody] RegisterProductModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Register
                {
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category,
                    SalePrice = model.SalePrice,
                    OriginPrice = model.OriginPrice,
                    Date = model.Date
                };

                _context.Register.Add(newProduct);
                _context.SaveChanges();

                return Ok(new { success = true });
            }
            return BadRequest(new { success = false });
        }

        [HttpPost]
        public IActionResult RegisterOrder([FromBody] List<ProductOrder> models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { success = false, message = "Invalid model state" });
            }

            var now = DateTime.UtcNow;
            var registerIds = models.Select(m => m.RegisterID).ToList();
            var registers = _context.Register.Where(r => registerIds.Contains(r.RegisterID)).ToList();
            var inventories = _context.Inventory.Where(i => registerIds.Contains(i.RegisterID)).ToList();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var model in models)
                    {
                        var register = registers.FirstOrDefault(r => r.RegisterID == model.RegisterID);
                        if (register == null)
                        {
                            return BadRequest(new { success = false, message = $"Invalid RegisterID: {model.RegisterID}" });
                        }

                        var newProduct = new Product
                        {
                            RegisterID = register.RegisterID,
                            Name = register.Name,
                            Category = register.Category,
                            Description = register.Description,
                            Price = register.SalePrice,
                            Status = model.Status,
                            Count = model.Quantity,
                            InBound = model.OutBound
                        };
                        _context.Products.Add(newProduct);

                        var inventory = inventories.FirstOrDefault(i => i.RegisterID == register.RegisterID);
                        if (inventory != null)
                        {
                            inventory.TotalQuantity += model.Quantity;
                            inventory.LastUpdated = now;
                        }
                        else
                        {
                            _context.Inventory.Add(new Inventory
                            {
                                RegisterID = register.RegisterID,
                                TotalQuantity = model.Quantity,
                                LastUpdated = now
                            });
                        }
                    }
                    _context.SaveChanges();
                    transaction.Commit();

                    return Ok(new { success = true });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(500, new { success = false, message = ex.Message });
                }
            }
        }


        [HttpDelete]
        public IActionResult DeleteRegister([FromBody] List<ProductDeleteRequest> registerIds)
        {
            if (registerIds == null || !registerIds.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var ids = registerIds.Select(r => r.RegisterID).ToList();
            
            // 데이터베이스에서 해당 IDs를 가진 제품들을 가져옵니다.
            var productsToDelete = _context.Register.Where(p => ids.Contains(p.RegisterID)).ToList();

            if (!productsToDelete.Any())
            {
                return NotFound("No products found for the provided IDs.");
            }

            // 가져온 제품들을 삭제합니다.
            _context.Register.RemoveRange(productsToDelete);
            _context.SaveChanges();

            return Ok(new { message = "Products deleted successfully." });
        }
    }
}