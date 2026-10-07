using lab8huamanialex.Models;

namespace lab8huamanialex.Repositories;

public interface ILabRepository
{
    Task<List<Client>> GetCustomersByNameAsync(string name);
    Task<List<Product>> GetProductsPriceGreaterThanAsync(decimal minPrice);
    Task<List<object>> GetProductDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<double> GetAverageProductPriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();
    Task<object?> GetCustomerWithMostOrdersAsync();
    Task<List<object>> GetAllOrdersWithDetailsAsync();
    Task<List<string>> GetProductsByCustomerIdAsync(int customerId);
    Task<List<string>> GetCustomersByProductIdAsync(int productId);
}