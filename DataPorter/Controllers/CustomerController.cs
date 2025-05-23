using DataPorter.Dto;
using DataPorter.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerBrowseDto>>> Get()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerBrowseDto>> GetCustomer(string id)
    => Ok(await _service.GetCustomer(id));

    [HttpPost]
    public async Task<IActionResult> Create(CustomerCreateDto dto)
    {
        try 
        {
            await _service.CreateAsync(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateDto dto)
    {
        try 
        {
            await _service.UpdateAsync(dto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try 
        {
            await _service.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
        return Ok();
    }
}
