using Microsoft.AspNetCore.Mvc;
using Poprawa2.Service;

namespace Poprawa2.Controllers;

[ApiController]
[Route("[controller]")]
public class GalleriesController:ControllerBase
{
    private readonly IGetGallery _getGallery;

    public GalleriesController(IGetGallery getGallery)
    {
        _getGallery = getGallery;
    }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var result = await _getGallery.GetGalleryByIdAsync(id);
            
            return Ok(result);
        }
        catch
        {
            return NotFound();
        }
    }
}