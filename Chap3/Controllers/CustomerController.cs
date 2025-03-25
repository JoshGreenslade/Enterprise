
using Chap3.Application;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers")]
public class CustomerController : Controller
{
    private CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] string name)
    {
        var result = await _customerService.AddNewCustomerAsync(name);
        return Ok(result);
    }

}