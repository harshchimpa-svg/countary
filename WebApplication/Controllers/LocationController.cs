using Application.locations;
using Application.locations.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProductApplication.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategaryController : ControllerBase
{
    private readonly ILocationApplications _Coustmor;

    public CategaryController(ILocationApplications categary)
    {
        _Coustmor = categary;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateLocationDto categary)
    {
        if (categary.locationType == LocationType.countary)
        {
            categary.ParentId = null;
        }
        else
        {
            if (categary.ParentId == null)
            {
                return BadRequest("ParentId is required for State or City");
            }

            var parent = await _Coustmor.GetById(categary.ParentId.Value);
            if (parent == null)
            {
                return BadRequest("Parent location does not exist");
            }
        }

        var id = await _Coustmor.categary(categary);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLocationDto dto)
    {
        await _Coustmor.Update(id, dto);
        return Ok("update successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _Coustmor.GetAll();
        return Ok(data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _Coustmor.GetById(id);

        if (employee == null)
            return NotFound("User not found");

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _Coustmor.delete(id);
        return Ok("user deleted successfully!");
    }
}
