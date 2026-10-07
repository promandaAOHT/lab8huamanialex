using Microsoft.AspNetCore.Mvc;
using lab8huamanialex.Repositories;

namespace lab8huamanialex.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabController : ControllerBase
{
    private readonly ILabRepository _repository;

    public LabController(ILabRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("ejercicio1/{name}")]
    public async Task<IActionResult> Ejercicio1(string name) => Ok(await _repository.GetCustomersByNameAsync(name));

    [HttpGet("ejercicio2/{minPrice}")]
    public async Task<IActionResult> Ejercicio2(decimal minPrice) => Ok(await _repository.GetProductsPriceGreaterThanAsync(minPrice));

    [HttpGet("ejercicio3/{orderId}")]
    public async Task<IActionResult> Ejercicio3(int orderId) => Ok(await _repository.GetProductDetailsByOrderIdAsync(orderId));

    [HttpGet("ejercicio4/{orderId}")]
    public async Task<IActionResult> Ejercicio4(int orderId) => Ok(await _repository.GetTotalProductQuantityByOrderIdAsync(orderId));

    [HttpGet("ejercicio5")]
    public async Task<IActionResult> Ejercicio5() => Ok(await _repository.GetMostExpensiveProductAsync());

    [HttpGet("ejercicio6/{date}")]
    public async Task<IActionResult> Ejercicio6(DateTime date) => Ok(await _repository.GetOrdersAfterDateAsync(date));

    [HttpGet("ejercicio7")]
    public async Task<IActionResult> Ejercicio7() => Ok(await _repository.GetAverageProductPriceAsync());

    [HttpGet("ejercicio8")]
    public async Task<IActionResult> Ejercicio8() => Ok(await _repository.GetProductsWithoutDescriptionAsync());

    [HttpGet("ejercicio9")]
    public async Task<IActionResult> Ejercicio9() => Ok(await _repository.GetCustomerWithMostOrdersAsync());

    [HttpGet("ejercicio10")]
    public async Task<IActionResult> Ejercicio10() => Ok(await _repository.GetAllOrdersWithDetailsAsync());

    [HttpGet("ejercicio11/{customerId}")]
    public async Task<IActionResult> Ejercicio11(int customerId) => Ok(await _repository.GetProductsByCustomerIdAsync(customerId));

    [HttpGet("ejercicio12/{productId}")]
    public async Task<IActionResult> Ejercicio12(int productId) => Ok(await _repository.GetCustomersByProductIdAsync(productId));
}