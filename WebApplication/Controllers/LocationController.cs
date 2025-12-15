using Application.locations;
using Application.locations.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProductApplication.Controllers;

[Route("api/Location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationApplications _locatin;

    public LocationController(ILocationApplications location)
    {
        _locatin = location;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateLocationDto location)
    {
        if (location.locationType == LocationType.Country)
        {
            location.ParentId = null;  
        }
        else
        {
            if (!location.ParentId.HasValue)
            {
                return BadRequest("ParentId is required for State or City");
            }

            if (location.ParentId.Value <= 0)
            {
                return BadRequest("ParentId must be a valid existing Id");
            }

            var parent = await _locatin.GetById(location.ParentId.Value);
            if (parent == null)
            {
                return BadRequest("Parent location does not exist");
            }
        }

        var id = await _locatin.categary(location);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLocationDto dto)
    {
        await _locatin.Update(id, dto);
        return Ok("update successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _locatin.GetAll();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {         
        var location = await _locatin.GetById(id);

        if (location == null)
            return NotFound("location not found");

        return Ok(location);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locatin.delete(id);
        return Ok("user deleted successfully!");
    }
}
    