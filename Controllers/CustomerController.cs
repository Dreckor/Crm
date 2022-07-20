using Microsoft.AspNetCore.Mvc;
using CRM.Services;
using CRM.Models;
namespace CRM.Controllers;

[ApiController]
[Route("Customer")]
public class MCustomersController : ControllerBase
{
    private readonly ILogger<MCustomersController> _logger;
    ICustomersService customersService;
    public MCustomersController(ILogger<MCustomersController> logger, ICustomersService customersService)
    {
        _logger = logger;
        this.customersService = customersService;
    }

    [HttpGet(Name="getCustomers")]
    public IActionResult Get()
    {
        return Ok(customersService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        return Ok(customersService.Post(customer));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Customer customer)
    {
        return Ok(customersService.Put(customer));
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(customersService.Delete(id));
    }
}
