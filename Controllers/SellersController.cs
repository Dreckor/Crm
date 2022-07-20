using Microsoft.AspNetCore.Mvc;
using CRM.Services;
using CRM.Models;
namespace CRM.Controllers;

[ApiController]
[Route("Sellers/[controller]")]
public class SellersController : ControllerBase
{
    private readonly ILogger<SellersController> _logger;
    ISellersService sellersService;
    public SellersController(ILogger<SellersController> logger, ISellersService sellersService)
    {
        _logger = logger;
        this.sellersService = sellersService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(sellersService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Seller seller)
    {
        return Ok(sellersService.Post(seller));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Seller seller)
    {
        return Ok(sellersService.Put(seller));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(sellersService.Delete(id));
    }
}
