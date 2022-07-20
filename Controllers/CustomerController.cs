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

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(customersService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Customer customer)
    {
        customersService.Add(customer);
        return Ok("Successfully added");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Customer customer)
    {
        customersService.Update(id, customer);
        return Ok("Successfully updated");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {   
        customersService.Delete(id);
        return Ok("Successfully deleted");
    }
}
