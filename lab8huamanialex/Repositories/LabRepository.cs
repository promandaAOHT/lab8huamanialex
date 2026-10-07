using Microsoft.EntityFrameworkCore;
using lab8huamanialex.Data;
using lab8huamanialex.Models;

namespace lab8huamanialex.Repositories;

public class LabRepository : ILabRepository
{
    private readonly ApplicationDbContext _context;

    public LabRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetCustomersByNameAsync(string name) =>
        await _context.Clients.Where(c => c.Name.Contains(name)).ToListAsync();

    public async Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal minPrice) =>
        await _context.Products.Where(p => p.Price > minPrice).ToListAsync();

    public async Task<List<object>> GetProductDetailsByOrderIdAsync(int orderId) =>
        await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .Select(od => new { ProductName = od.Product!.Name, Quantity = od.Quantity })
            .Cast<object>()
            .ToListAsync();

    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId) =>
        await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity);

    public async Task<Product?> GetMostExpensiveProductAsync() =>
        await _context.Products.OrderByDescending(p => p.Price).FirstOrDefaultAsync();

    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date) =>
        await _context.Orders.Where(o => o.OrderDate > date).ToListAsync();

    public async Task<double> GetAverageProductPriceAsync() =>
        (double)await _context.Products.AverageAsync(p => p.Price);

    public async Task<List<Product>> GetProductsWithoutDescriptionAsync() =>
        await _context.Products.Where(p => string.IsNullOrEmpty(p.Description)).ToListAsync();

    public async Task<object?> GetCustomerWithMostOrdersAsync() =>
        await _context.Orders
            .GroupBy(o => o.ClientId)
            .OrderByDescending(g => g.Count())
            .Select(g => new { ClientId = g.Key, TotalOrders = g.Count() })
            .FirstOrDefaultAsync();

    public async Task<List<object>> GetAllOrdersWithDetailsAsync() =>
        await _context.OrderDetails
            .Include(od => od.Product)
            .Select(od => new { od.OrderId, ProductName = od.Product!.Name, od.Quantity })
            .Cast<object>()
            .ToListAsync();

    public async Task<List<string>> GetProductsByCustomerIdAsync(int customerId) =>
        await _context.Orders
            .Where(o => o.ClientId == customerId)
            .SelectMany(o => o.OrderDetails)
            .Select(od => od.Product!.Name)
            .Distinct()
            .ToListAsync();

    public async Task<List<string>> GetCustomersByProductIdAsync(int productId) =>
        await _context.OrderDetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order!.Client!.Name)
            .Distinct()
            .ToListAsync();
}