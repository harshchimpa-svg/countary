using Application.locations;
using Application.locations.Dto;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProductApplication.Controllers;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationApplications _location;

    public LocationController(ILocationApplications location)
    {
        _location = location;
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

            var parent = await _location.GetById(location.ParentId.Value);
            if (parent == null)
            {
                return BadRequest("Parent location does not exist");
            }
        }

        var id = await _location.Create(location);
        return Ok(id);  
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLocationDto dto)
    {
        await _location.Update(id, dto);
        return Ok("update successfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _location.GetAll();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {         
        var location = await _location.GetById(id);

        if (location == null)
            return NotFound("location not found");

        return Ok(location);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _location.Delete(id);
        return Ok("user deleted successfully!");
    }
}
    