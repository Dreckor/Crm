using Microsoft.AspNetCore.Mvc;
using CRM.Services;
using CRM.Models;
namespace CRM.Controllers;

[ApiController]
[Route("[controller]")]
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
        sellersService.Add(seller);
        return Ok("Successfully added");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Seller seller)
    {
        sellersService.Update(id, seller);
        return Ok("Successfully updated");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        sellersService.Delete(id);
        return Ok("Successfully deleted");
    }

    [HttpGet]
    [Route("CreateDB")]
    public IActionResult CreateSellerBase(){
        sellersService.CreateTable();
        return Ok();
    }
}
